using AutoMapper;
using MyCookbook.Aplication.Services.Cryptography;
using MyCookbook.Aplication.Services.Token;
using MyCookbook.Communication.Request;
using MyCookbook.Communication.Response;
using MyCookbook.Domain.Entities;
using MyCookbook.Domain.Repositories;
using MyCookbook.Exceptions;
using MyCookbook.Exceptions.ExceptionBase;

namespace MyCookbook.Aplication.UseCases.Users.Register;

public class RegisterUserUseCase(
    IUsersRepository userRepository, 
    IMapper mapper, 
    IUnitWorkRepository unitWork, 
    PasswordEncryptor passwordEncryptor,
    TokenController tokenController) : IRegisterUserUseCase
{
    private readonly IUsersRepository _usersRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitWorkRepository _unitWork = unitWork;
    private readonly PasswordEncryptor _passwordEncryptor = passwordEncryptor;
    private readonly TokenController _tokenController = tokenController;

    public async Task<RegisteredUserResponse> Execute(RequestRegisterUser requestRegisterUser) 
    {
        await Validate(requestRegisterUser);
        var entity = _mapper.Map<UserEntity>(requestRegisterUser);
        entity.Password = _passwordEncryptor.Encrypt(requestRegisterUser.Password);

        await _usersRepository.Create(entity);
        await _unitWork.Commit();

        var token = _tokenController.GenerateToken(requestRegisterUser.Email);
        
        return new RegisteredUserResponse() { Token = token};
    }

    private async Task Validate(RequestRegisterUser requestRegisterUser)
    {
        var registerUserValidator = new RegisterUserValidator();
        var result = registerUserValidator.Validate(requestRegisterUser);

        var userExists = await _usersRepository.CheckEmailExists(requestRegisterUser.Email);
        
        if (userExists)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceErrorMessage.ALREADY_REGISTERED_EMAIL));
        }

        if (!result.IsValid)
        {
            var errorMessage = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessage);
        }
    }
}

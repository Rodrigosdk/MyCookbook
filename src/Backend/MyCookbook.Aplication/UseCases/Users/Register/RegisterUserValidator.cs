using FluentValidation;
using MyCookbook.Communication.Request;
using MyCookbook.Exceptions;
using System.Text.RegularExpressions;

namespace MyCookbook.Aplication.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUser>
{
    public RegisterUserValidator()
    {
        RuleFor(c=> c.Name).NotEmpty().WithMessage(ResourceErrorMessage.USER_NAME_EMPTY);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceErrorMessage.USER_EMAIL_EMPTY);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceErrorMessage.USER_EMAIL_EMPTY);
        RuleFor(c => c.Password).NotEmpty().WithMessage(ResourceErrorMessage.USER_PASSWORD_EMPTY);
        RuleFor(c => c.Phone).NotEmpty().WithMessage(ResourceErrorMessage.USER_PHONE_EMPTY);
        When(c => !string.IsNullOrWhiteSpace(c.Email),() => RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceErrorMessage.INCORRECT_USER_EMAIL));
        When(c => !string.IsNullOrWhiteSpace(c.Password), () => RuleFor(c => c.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceErrorMessage.MINIMUM_CHARACTER_PASSWORD));
        When(c => !string.IsNullOrWhiteSpace(c.Phone), () => RuleFor(c => c.Phone).Custom((phone, context) =>
        {
            var telephonePattern = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
            var isMatch =  Regex.IsMatch(phone, telephonePattern);
            
            if (!isMatch) {
                context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(phone), ResourceErrorMessage.INCORRECT_USER_PHONE));
            }
        
        }));
    }
}

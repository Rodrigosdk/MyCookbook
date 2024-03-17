using MyCookbook.Communication.Request;
using MyCookbook.Communication.Response;

namespace MyCookbook.Aplication.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    public Task<RegisteredUserResponse> Execute(RequestRegisterUser requestRegisterUser);
}

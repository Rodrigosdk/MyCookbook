using Microsoft.AspNetCore.Mvc;
using MyCookbook.Aplication.UseCases.Users.Register;
using MyCookbook.Communication.Request;
using MyCookbook.Communication.Response;

namespace MyCookbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUser request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
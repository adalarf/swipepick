using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swipepick.UseCases.Users.AddUser;
using Swipepick.UseCases.Users.GetUser;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserAuthController : Controller
    {
        private readonly IMediator mediator;

        public UserAuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(GetUserQuery query, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(query, cancellationToken);

            if (result == null)
                return BadRequest(new { errorText = "User Not Found" });

            var tokenString = result.Token;
            return Json(new { token = tokenString, userEmail = result.Email });

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(AddUserCommand addUserCommand)
        {
            await mediator.Send(addUserCommand);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/swipepick/user")]
    public class UserController : Controller
    {
        public UserController()
        {

        }

        [Authorize]
        [HttpPost("create-test")]
        public IActionResult CreateTest()
        {
            return Ok();
        }
    }
}

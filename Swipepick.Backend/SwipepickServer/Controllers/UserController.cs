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
        [HttpGet("teacher/list")]
        public IActionResult GetTests()
        {
            return Ok();
        }
    }
}

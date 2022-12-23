using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/swipepick/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        [Authorize]
        [HttpPost("create-test")]
        public IActionResult CreateTest([FromHeader] string email, Dictionary<string, List<string>> questions)
        {
            _user.AddTest(email, questions);
            return Ok(email);
        }

        [HttpGet("get-tests")]
        [Authorize]
        public IActionResult Test([FromHeader] string email)
        {
            var tests = _user.GetTests(email);
            return Ok(tests);
        }
    }
}

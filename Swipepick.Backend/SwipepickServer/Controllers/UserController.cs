using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("get-tests")]
        public IActionResult Test()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var tests = _user.GetTests(email.Value);
            return Ok(tests);
        }

        [Authorize]
        [HttpGet("get-email")]
        public IActionResult GetEmail()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            return Json(new { email = email.Value });
        }
    }
}

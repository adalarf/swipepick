using DAL.Entities;
using DAL.Entities.Dto;
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
        public IActionResult CreateTest(TestDto test)
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            _user.AddTest(email.Value, test);
            return Ok(email.Value);
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

        [Authorize]
        [HttpGet("test-urls")]
        public IActionResult GetTestsUrls()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var urls = new List<string>();
            var tests = _user.GetTests(email.Value);
            foreach (var test in tests)
            {
                urls.Add(test.Url);
            }
            return Ok(urls);
        }
    }
}

using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/swipepick/user")]
    public class UserController : Controller
    {
        private IUserRepository _user;

        public UserController(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        //[Authorize]
        [HttpPost("create-test")]
        public IActionResult CreateTest(int userId, List<QuestionDal> questions)
        {
            _user.AddTest(userId, questions);
            return Ok(userId);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok(1);
        }
    }
}

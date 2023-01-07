using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/swipepick/test")]
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetTest([FromQuery] string testUri)
        {
            var test = _testRepository.GetTest(testUri);
            if (test == null)
                return BadRequest("Test not found");
            return Json(test);
        }
    }
}

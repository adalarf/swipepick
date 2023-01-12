using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("swipepick/test")]
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [AllowAnonymous]
        [HttpGet("{uri}")]
        public IActionResult GetTest([FromRoute] string uri)
        {
            var test = _testRepository.GetTest(uri);
            var quest = test.Questions
                .Select(x => new
                {
                    QueId = x.Id,
                    Question = x.Question,
                    Options = new[] 
                    {
                        x.Answers.FirstAnswer,
                        x.Answers.SecondAnswer,
                        x.Answers.ThirdAnswer,
                        x.Answers.FourhAnswer
                    }
                }).OrderBy(y => Guid.NewGuid());
            if (test == null)
                return BadRequest("Test not found");
            return Json(quest);
        }
    }
}

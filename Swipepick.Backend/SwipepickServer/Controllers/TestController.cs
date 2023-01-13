using DAL.Entities.Dto;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
                    QueId = x.QueId,
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

        [AllowAnonymous]
        [HttpPost("submit-answers")]
        public IActionResult SubmitAnswers([FromBody] StudentAnswerDto studentAnswer)
        {
            var test = _testRepository.GetTest(studentAnswer.TestUri);
            var count = GetTestResult(test, studentAnswer);
            return Ok(count);
        }

        private int GetTestResult(TestDto test, StudentAnswerDto studentAnswer)
        {
            var currectAnsw = studentAnswer.SelectedAnsws.GroupBy(x => x.QueId);
            var questions = test.Questions.Select(x => x).ToList();
            var count = 0;
            var correctAnsw = questions.Select(x => x.Answers).GroupBy(x => x.QueId);
            foreach (var t in currectAnsw)
            {
                var group = correctAnsw.Single(g => g.Key == t.Key);
                var y = currectAnsw.Single(g => g.Key == t.Key);
                var currentAns = y.Select(x => x).First();
                var tight = group.Select(x => x).First();
                if (tight.CorrectAnswer == currentAns.Answ)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

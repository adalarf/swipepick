using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swipepick.DomainServices;
using Swipepick.UseCases.Tests.CreateTest;
using Swipepick.UseCases.Tests.GetTestByCode;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/tests")]
    public class TestController : Controller
    {
        private readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(
            CreateTestCommand createTestCommand,
            CancellationToken cancellationToken = default)
        {
            await mediator.Send(createTestCommand, cancellationToken);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{uniqueCode}")]
        public async Task<IActionResult> GetTest(
            [FromRoute] string uniqueCode,
            CancellationToken cancellationToken = default)
        {
            var test = await mediator.Send(new GetTestByCodeQuery(uniqueCode), cancellationToken);

            if (test == null)
                return BadRequest("Test not found");

            var quest = test.Questions
                .Select(x => new
                {
                    QueId = x.QueId,
                    Question = x.Question,
                    Options = test.Questions.Select(q => q.Question)
                }).OrderBy(y => Guid.NewGuid());

            return Json(quest);
        }

        [AllowAnonymous]
        [HttpPost("submit-answers")]
        public async Task<IActionResult> SubmitAnswers(
            [FromBody] StudentAnswerDto studentAnswer, 
            CancellationToken cancellationToken = default)
        {
            var test = await mediator.Send(new GetTestByCodeQuery(studentAnswer.TestCode), cancellationToken);
            var count = GetTestResult(test, studentAnswer);
            return Ok(count);
        }

        private int GetTestResult(TestDto test, StudentAnswerDto studentAnswer)
        {
            var currectAnsw = studentAnswer.SelectedAnswers.GroupBy(x => x.QuestionId);
            var questions = test.Questions.Select(x => x).ToList();
            var count = 0;
            var correctAnsw = questions.Select(x => x.Answers.First()).GroupBy(x => x.QueId);
            foreach (var t in currectAnsw)
            {
                var group = correctAnsw.Single(g => g.Key == t.Key);
                var y = currectAnsw.Single(g => g.Key == t.Key);
                var currentAns = y.Select(x => x).First();
                var tight = group.Select(x => x).First();
                if (tight.CorrectAnswer == currentAns.AnswerCode)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

using DAL.AppDBContext;
using DAL.Entities.Dto;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly UserContext _userContext;

        public TestRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public TestDto? GetTest(string uri)
        {
            var test = _userContext.Tests.Where(x => x.Url == uri).Include(x => x.Questions).FirstOrDefault();
            if (test == null)
                return null;
            var queDtos = new List<QuestionDto>();
            foreach (var que in test.Questions)
            {
                var queAnswers = que.Answers;
                var answersDto = new AnswerDto()
                {
                    FirstAnswer = queAnswers.FirstAnswer,
                    SecondAnswer = queAnswers.SecondAnswer,
                    ThirdAnswer = queAnswers.ThirdAnswer,
                    FourhAnswer = queAnswers.FourhAnswer,
                    CorrectAnswer = queAnswers.CorrectAnswer,
                    QueId = que.QueId
                };
                var queDto = new QuestionDto() { Answers = answersDto, Question = que.Question, QueId = que.QueId };
                queDtos.Add(queDto);
            }
            var result = new TestDto() { Questions = queDtos };
            return result;
        }
    }
}

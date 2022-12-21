using DAL.AppDBContext;
using DAL.Entities;
using DAL.Repository.Interfaces;


namespace DAL.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly UserContext _userContext;

        public TestRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public List<QuestionDal> GetQuestions(int testId)
        {
            var questions = _userContext.Questions.Where(x => x.TestId == testId).ToList();
            foreach (var question in questions)
            {
                var id = question.Id;
                question.Answers = _userContext.Answers.FirstOrDefault(x => x.QuestionId == id);
            }

            return questions;
        }
    }
}

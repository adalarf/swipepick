//using DAL.AppDBContext;
//using DAL.Entities.Dto;
//using DAL.Repository.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using Swipepick.Domain;
//using System.Security.Cryptography;
//using System.Text;

//namespace DAL.Repository
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _userContext;

//        public UserRepository(ApplicationDbContext userContext)
//        {
//            _userContext = userContext;
//        }

//        public bool IsUserExsist(string userEmail)
//        {
//            return _userContext.Users.Any(x => x.Email == userEmail);
//        }

//        public void AddUser(UserDto user)
//        {

//            HashPassword(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
//            var newUser = new User()
//            {
//                Email = user.Email,
//                PasswordHash = passwordHash,
//                PasswordSalt = passwordSalt,
//                Name = user.Name,
//                Lastname = user.Lastname
//            };

//            _userContext.Users.Add(newUser);
//            _userContext.SaveChanges();
//        }

//        public User? GetUser(UserLogin user)
//        {
//            var exsitingUser = _userContext.Users.FirstOrDefault(us => us.Email == user.Email);

//            if (exsitingUser == null)
//                return null;

//            if (!VerifyPasswordHash(user.Password, exsitingUser.PasswordHash, exsitingUser.PasswordSalt))
//                return null;

//            return exsitingUser;
//        }

//        public void AddTest(string email, TestDto testDto)
//        {
//            var user = _userContext.Users.FirstOrDefault(x => x.Email == email);
//            var testGuid = Guid.NewGuid().ToString().Substring(0, 4);
//            var questions = new List<Question>();
//            var test = new Test() { UniqueCode = testGuid, User = user, UserId = user.Id, Students = null };

//            foreach (var question in testDto.Questions)
//            {
//                var answerId = new Random().Next(50, 20000);
//                var questionId = new Random().Next(1, 200000);

//                var newQuestion = new Question()
//                {
//                    QuestionContent = question.Question,
//                    Id = questionId,
//                    Test = test,
//                    TestId = test.Id,
//                };

//                var answs = new Answer()
//                {
//                    Id = answerId,
//                    Question = newQuestion,
//                    QuestionId = questionId,
//                    FirstAnswer = question.Answers.FirstAnswer,
//                    SecondAnswer = question.Answers.SecondAnswer,
//                    ThirdAnswer = question.Answers.ThirdAnswer,
//                    FourhAnswer = question.Answers.FourhAnswer,
//                    CorrectAnswer = question.Answers.CorrectAnswer,
//                };

//                newQuestion.Answers = answs;
//                questions.Add(newQuestion);
//            }
//            test.Questions = questions;
//            _userContext.Tests.Add(test);
//            _userContext.SaveChanges();
//        }

//        public List<TestDal> GetTests(string email)
//        {
//            var user = _userContext.Users.FirstOrDefault(x => x.Email == email);
//            var tests = _userContext.Tests.Where(x => x.UserId == user.Id).Include(x => x.Questions);

//            return tests.ToList();
//        }

//        private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        {
//            using (var hmac = new HMACSHA512())
//            {
//                passwordSalt = hmac.Key;
//                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
//            }
//        }

//        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
//        {
//            using (var hmac = new HMACSHA512(passwordSalt))
//            {
//                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
//                return computeHash.SequenceEqual(passwordHash);
//            }
//        }
//    }
//}

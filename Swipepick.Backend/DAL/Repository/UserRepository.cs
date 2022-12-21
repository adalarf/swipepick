using DAL.AppDBContext;
using DAL.Entities;
using DAL.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        private ITestRepository _test;

        public UserRepository(UserContext userContext, ITestRepository test)
        {
            _userContext = userContext;
            _test = test;
        }

        public void AddUser(UserDto user)
        {

            HashPassword(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var newUser = new User()
            {
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = user.Name,
                Lastname = user.Lastname
            };

            _userContext.Users.Add(newUser);
            _userContext.SaveChanges();
        }

        public User? GetUser(UserLogin user)
        {
            var exsitingUser = _userContext.Users.FirstOrDefault(us => us.Email == user.Email);

            if (exsitingUser == null)
                return null;

            if (!VerifyPasswordHash(user.Password, exsitingUser.PasswordHash, exsitingUser.PasswordSalt))
                return null;

            return exsitingUser;
        }

        public void AddTest(int userId, List<QuestionDal> questions)
        {
            var segment = Guid.NewGuid().ToString().Substring(0, 4);
            var test = new TestDal()
            {
                Url = segment,
                UserId = userId,
                Questions = questions
            };

            _userContext.Tests.Add(test);
        }

        public List<TestDal> GetTests(int userId)
        {
            var result = new List<TestDal>();
            var tests = _userContext.Tests.Where(x => x.UserId == userId).ToList();
            foreach (var test in tests)
            {
                var questions = _test.GetQuestions(test.Id);
                var newTest = new TestDal()
                {
                    Id = test.Id,
                    Url = test.Url,
                    User = test.User,
                    UserId = test.UserId,
                    Students = test.Students,
                    Questions = questions
                };
                result.Add(newTest);
            }

            return result;
        }

        private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}

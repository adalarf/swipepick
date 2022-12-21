using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(UserLogin user);

        List<TestDal> GetTests(int userId);

        void AddUser(UserDto user);

        void AddTest(int userId, List<QuestionDal> questions);
    }
}

using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(UserLogin user);

        List<TestDal> GetTests(string email);

        void AddUser(UserDto user);

        void AddTest(string email, Dictionary<string, List<string>> qustions);

        bool IsUserExsist(string email);
    }
}

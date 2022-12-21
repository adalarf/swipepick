using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(UserLogin user);

        void AddUser(UserDto user);

        void AddTest(int userId, List<QuestionDal> questions);
    }
}

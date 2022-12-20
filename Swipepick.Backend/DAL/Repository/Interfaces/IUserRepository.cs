using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(UserDto user);

        void AddUser(UserDto user);
    }
}

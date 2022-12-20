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

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
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

        public User? GetUser(UserDto user)
        {
            var exsitingUser = _userContext.Users.FirstOrDefault(us => us.Email == user.Email);

            if (exsitingUser == null)
                return null;

            if (!VerifyPasswordHash(user.Password, exsitingUser.PasswordHash, exsitingUser.PasswordSalt))
                return null;

            return exsitingUser;
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

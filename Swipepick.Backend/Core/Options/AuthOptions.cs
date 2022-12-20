using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Options
{
    public class AuthOptions
    {
        public const string ISSUER = "SwipepickApi"; 
        public const string AUDIENCE = "SwipepickClient"; 
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

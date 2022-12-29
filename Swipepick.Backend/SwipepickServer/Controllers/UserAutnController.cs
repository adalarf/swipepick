using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class UserAutnController : Controller
    {
        private IUserRepository _user;
        private readonly IConfiguration _config;

        public UserAutnController(IUserRepository userRepository, IConfiguration configuration)
        {
            _user = userRepository;
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            var userDto = _user.GetUser(user);

            if (userDto == null)
                return BadRequest(new { errorText = "User Not Found" });

            var tokenString = GenerateJwt(userDto);
            return Json(new { token = tokenString, userEmail = userDto.Email });

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (!_user.IsUserExsist(userDto.Email))
            {
                _user.AddUser(userDto);
                return Json(new { userEmail = userDto.Email });
            }

            return BadRequest("ERROR: Пользователь с такой почтой уже зарегестрирован");
        }

        private List<Claim> GetClaims(User user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Lastname),
                    new Claim("Date", DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                return claims;
            }

            // если пользователя не найдено
            return null;
        }

        private string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtAuth:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = GetClaims(user);
            var token = new JwtSecurityToken(_config["JwtAuth:Issuer"],
              _config["JwtAuth:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

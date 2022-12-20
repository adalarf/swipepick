using Core.Options;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class UserAutnController : Controller
    {
        private IUserRepository _user;

        public UserAutnController(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            var userDto = new UserDto() { Email = user.Email, Password = user.Password };
            var identity = GetIdentity(userDto);

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            _user.AddUser(userDto);
            return Ok(userDto.Email);
        }

        private ClaimsIdentity GetIdentity(UserDto userDto)
        {
            
            var user = _user.GetUser(userDto);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                                                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        public class UserLogin
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }
    }
}

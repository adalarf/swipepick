﻿using Core.Options;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult Login(UserLogin user)
        {
            var userDto = _user.GetUser(user);

            if (userDto == null)
                return BadRequest(new { errorText = "User Not Found" });

            var tokenString = GenerateJwt(userDto);
            return Ok(new { token = tokenString });

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            _user.AddUser(userDto);
            return Ok(userDto.Email);
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

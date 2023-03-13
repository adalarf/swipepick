using DAL.AppDBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swipepick.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Swipepick.UseCases.Users.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResult>
{
    private readonly ApplicationDbContext dbContext;
    private readonly IConfiguration configuration;

    public GetUserQueryHandler(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }

    public async Task<GetUserQueryResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.UserLoginDto.Email, cancellationToken);

        if (user != null)
        {
            if (!VerifyPasswordHash(request.UserLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return new GetUserQueryResult()
            {
                Email = user.Email,
                Token = GenerateJwt(user)
            };
        }

        return null;
    }

    private List<Claim> GetClaims(User user)
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

    private string GenerateJwt(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtAuth:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = GetClaims(user);
        var token = new JwtSecurityToken(configuration["JwtAuth:Issuer"],
          configuration["JwtAuth:Issuer"],
          claims,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
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

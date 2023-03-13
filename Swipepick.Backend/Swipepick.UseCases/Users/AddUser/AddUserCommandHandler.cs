using AutoMapper;
using DAL.AppDBContext;
using MediatR;
using Swipepick.Domain;
using System.Security.Cryptography;
using System.Text;

namespace Swipepick.UseCases.Users.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
{
    private readonly ApplicationDbContext dbContext;
    private readonly IMapper mapper;

    public AddUserCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.User);
        HashPassword(request.User.Password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Domain;
using Swipepick.Infrastructure.Abstraction.Interfaces;

namespace Swipepick.UseCases.Tests.CreateTest;

public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    public CreateTestCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken);
        if (user != null)
        {
            var test = mapper.Map<Test>(request.TestDto);
            test.UniqueCode = Guid.NewGuid().ToString().Split("-")[0];
            test.User = user;
            test.UserId = user.Id;
            dbContext.Tests.Add(test);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

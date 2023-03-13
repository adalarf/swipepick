using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.DataAccess.AppDBContext;
using Swipepick.Domain;

namespace Swipepick.UseCases.Tests.CreateTest;

public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand>
{
    private readonly ApplicationDbContext dbContext;
    private readonly IMapper mapper;

    public CreateTestCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
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
        }
    }
}

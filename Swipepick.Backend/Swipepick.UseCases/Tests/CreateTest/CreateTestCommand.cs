using MediatR;
using Swipepick.DomainServices;

namespace Swipepick.UseCases.Tests.CreateTest;

public record CreateTestCommand : IRequest
{
    public string UserEmail { get; init; }

    public TestDto TestDto { get; init; }
}

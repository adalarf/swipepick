using Swipepick.DomainServices;

namespace Swipepick.UseCases.Tests.GetTests;

public record GetTestsQueryResult
{
    public List<TestDto> Tests { get; init; } = new List<TestDto>();
}

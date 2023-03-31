using MediatR;

namespace Swipepick.UseCases.Tests.GetTests;

public record GetTestsQuery(string UserEmail) : IRequest<GetTestsQueryResult>;

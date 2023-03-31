using MediatR;
using Swipepick.DomainServices;

namespace Swipepick.UseCases.Tests.GetTestByCode;

public record GetTestByCodeQuery(string UniqueCode) : IRequest<TestDto>;

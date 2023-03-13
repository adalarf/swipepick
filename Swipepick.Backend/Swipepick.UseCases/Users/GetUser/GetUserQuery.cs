using MediatR;
using Swipepick.DomainServices;

namespace Swipepick.UseCases.Users.GetUser;

public record GetUserQuery : IRequest<GetUserQueryResult>
{
    public UserLoginDto UserLoginDto { get; init; }
}

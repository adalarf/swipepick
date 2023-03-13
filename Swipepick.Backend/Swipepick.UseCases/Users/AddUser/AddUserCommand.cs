using MediatR;
using Swipepick.DomainServices;

namespace Swipepick.UseCases.Users.AddUser
{
    public record AddUserCommand : IRequest
    {
        public UserDto User { get; init; } 
    }
}

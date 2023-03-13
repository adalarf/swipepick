namespace Swipepick.DomainServices;

public record UserDto
{
    public string Email { get; init; }

    public string Password { get; init; }

    public string Name { get; init; }

    public string LastName { get; init; }
}

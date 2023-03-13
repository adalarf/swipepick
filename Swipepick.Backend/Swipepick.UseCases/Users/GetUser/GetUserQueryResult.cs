namespace Swipepick.UseCases.Users.GetUser;

public record GetUserQueryResult
{
    public string Email { get; init; }

    public string Token { get; init; }
}

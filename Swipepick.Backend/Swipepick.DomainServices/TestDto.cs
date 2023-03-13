namespace Swipepick.DomainServices;

public record TestDto
{
    public List<StudentDto> Students { get; init; }

    public List<QuestionDto> Questions { get; init; }
}

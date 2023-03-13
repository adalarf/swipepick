namespace Swipepick.DomainServices;

public record QuestionDto
{
    public string Question { get; init; }

    public List<AnswerDto> Answers { get; init; }
}

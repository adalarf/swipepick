namespace Swipepick.DomainServices;

public record QuestionDto
{
    public int QueId { get; init; }

    public string Question { get; init; }

    public List<AnswerDto> Answers { get; init; }
}

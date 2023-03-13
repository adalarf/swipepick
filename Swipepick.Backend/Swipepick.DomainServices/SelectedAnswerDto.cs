namespace Swipepick.DomainServices;

public record SelectedAnswerDto
{
    public int QuestionId { get; init; }

    public int AnswerCode { get; init; }
}


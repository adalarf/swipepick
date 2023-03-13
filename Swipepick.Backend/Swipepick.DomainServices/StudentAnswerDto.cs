namespace Swipepick.DomainServices;

public record StudentAnswerDto
{
    public string TestCode { get; init; }

    public List<SelectedAnswerDto> SelectedAnswers { get; init; }
}

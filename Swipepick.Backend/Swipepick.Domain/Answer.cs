using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class Answer
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public Question Question { get; set; }

    public ICollection<AnswerVariant> AnswerVariants { get; set; } = new List<AnswerVariant>();

    public int CorrectAnswer { get; set; }
}

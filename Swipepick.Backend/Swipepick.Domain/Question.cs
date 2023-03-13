using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class Question
{
    [Key]
    public int Id { get; set; }

    public int TestId { get; set; }

    public Test Test { get; set; }

    public string QuestionContent { get; set; }

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}

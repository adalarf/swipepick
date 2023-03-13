using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class AnswerVariant
{
    [Key]
    public int Id { get; set; }

    public Answer Answer { get; set; }

    public string Variant { get; set; }
}

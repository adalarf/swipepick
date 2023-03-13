using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class Test
{
    [Key]
    public int Id { get; set; }

    public string UniqueCode { get; set; }

    public int UserId { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();

    public User User { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class Student
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public User User { get; set; }

    public ICollection<Test> Tests { get; set; } = new List<Test>();
}

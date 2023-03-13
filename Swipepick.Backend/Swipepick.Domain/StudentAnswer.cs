using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class StudentAnswer
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }

    public string FirstAnswer { get; init; }

    public string SecondAnswer { get; init; }

    public string ThirdAnswer { get; init; }

    public string FourhAnswer { get; init; }

}
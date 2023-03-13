using System.ComponentModel.DataAnnotations;

namespace Swipepick.Domain;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public ICollection<Test> Tests { get; set; } = new List<Test>();

    public ICollection<Student> Students { get; set; } = new List<Student>();
}

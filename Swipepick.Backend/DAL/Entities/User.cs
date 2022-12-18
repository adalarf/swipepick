using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("User")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Column("name")]
        public string Name { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }

        public List<TestDal> Tests { get; set; }

        public List<StudentDal> Students { get; set; }
    }
}
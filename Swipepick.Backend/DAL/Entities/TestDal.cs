using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Entities
{
    [Table("Test")]
    [Index(nameof(Url), IsUnique = true)]
    public class TestDal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Column("url")]
        public string Url { get; init; }

        [Column("user_id")]
        public int UserId { get; init; }

        [Column("question")]
        public QuestionDal Question { get; init; }

        public User User { get; init; }

        public List<StudentDal> Students { get; set; }
    }
}

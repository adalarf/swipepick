
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Student")]
    public class StudentDal
    {
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("test_id")]
        public int TestId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        public List<StudentAnswerDal> StudentAnswers { get; set; }

        public User User { get; set; }

        public TestDal Test { get; set; }
    }
}
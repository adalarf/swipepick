using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Dal
{
    [Owned]
    [Table("Student_Answer")]
    public class StudentAnswerDal
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentDal Student { get; set; }

        [Column("answer_1")]
        public string FirstAnswer { get; init; }

        [Column("answer_2")]
        public string SecondAnswer { get; init; }

        [Column("answer_3")]
        public string ThirdAnswer { get; init; }

        [Column("answer_4")]
        public string FourhAnswer { get; init; }
    }
}
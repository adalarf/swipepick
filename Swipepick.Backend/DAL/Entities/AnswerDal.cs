using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Entities
{
    [Table("Answer")]
    public class AnswerDal
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public QuestionDal Question { get; set; }

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

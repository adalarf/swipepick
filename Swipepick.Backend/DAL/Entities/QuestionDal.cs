using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("test_question")]
    public class QuestionDal
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public TestDal Test { get; set; }
        public string Question { get; set; }
        public AnswerDal Answers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [Table("Answer")]
    public class AnswerDal
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [JsonIgnore]
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

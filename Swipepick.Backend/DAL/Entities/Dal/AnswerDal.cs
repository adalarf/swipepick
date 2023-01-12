using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities.Dal
{
    [Table("Answer")]
    public class AnswerDal
    {
        [JsonPropertyName("answer_id")]
        public int Id { get; set; }

        [JsonPropertyName("test_id")]
        public int TestId { get; set; }

        [JsonPropertyName("question_id")]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public QuestionDal Question { get; set; }

        [JsonPropertyName("answer_1")]
        [Column("answer_1")]
        public string FirstAnswer { get; init; }

        [JsonPropertyName("answer_2")]
        [Column("answer_2")]
        public string SecondAnswer { get; init; }

        [JsonPropertyName("answer_3")]
        [Column("answer_3")]
        public string ThirdAnswer { get; init; }

        [JsonPropertyName("answer_4")]
        [Column("answer_4")]
        public string FourhAnswer { get; init; }

        public int QueId { get; set; }

        [JsonPropertyName("correct")]
        [Column("correct_ans")]
        public int CorrectAnswer { get; set; }
    }
}

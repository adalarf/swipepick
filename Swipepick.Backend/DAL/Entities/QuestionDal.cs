using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [Table("Test_question")]
    public class QuestionDal
    {
        [JsonPropertyName("qustion_id")]
        public int Id { get; set; }

        public int TestId { get; set; }

        [JsonIgnore]
        public TestDal Test { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        public AnswerDal Answers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities.Dal
{
    [Table("Test")]
    [Index(nameof(Url), IsUnique = true)]
    public class TestDal
    {
        [JsonPropertyName("test_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [JsonPropertyName("test_url")]
        [Column("url")]
        public string Url { get; init; }

        [JsonPropertyName("user_id")]
        [Column("user_id")]
        public int UserId { get; init; }

        [Column("question")]
        public List<QuestionDal> Questions { get; set; }

        [JsonIgnore]
        public User User { get; init; }

        public List<StudentDal> Students { get; set; }

        [JsonIgnore]
        public List<CorrectAnswer> CorrectAnswers { get; set; }
    }
}
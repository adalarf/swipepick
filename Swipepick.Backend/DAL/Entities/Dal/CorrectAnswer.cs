using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities.Dal
{
    public class CorrectAnswer
    {
        public int Id { get; set; }
        public int TestId { get; set; }

        public string Answer { get; set; }

        [JsonIgnore]
        public TestDal Test { get; set; }
    }
}

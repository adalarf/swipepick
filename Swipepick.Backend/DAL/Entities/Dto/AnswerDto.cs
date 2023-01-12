using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities.Dto
{
    public class AnswerDto
    {
        [JsonPropertyName("answer_1")]
        public string FirstAnswer { get; init; }

        [JsonPropertyName("answer_2")]
        public string SecondAnswer { get; init; }

        [JsonPropertyName("answer_3")]
        public string ThirdAnswer { get; init; }

        [JsonPropertyName("answer_4")]
        public string FourhAnswer { get; init; }

        public int QueId { get; set; }

        public int CorrectAnswer { get; set; }
    }
}

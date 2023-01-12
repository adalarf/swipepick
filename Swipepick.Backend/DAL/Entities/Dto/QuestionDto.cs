using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public AnswerDto Answers { get; set; }
    }
}

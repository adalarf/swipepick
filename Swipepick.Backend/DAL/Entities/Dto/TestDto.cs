using DAL.Entities.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Dto
{
    public class TestDto
    {
        public List<QuestionDal> Questions { get; set; }
    }
}

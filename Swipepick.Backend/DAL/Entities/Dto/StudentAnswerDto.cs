
namespace DAL.Entities.Dto
{
    public class StudentAnswerDto
    {
        public string TestUri { get; set; }
        public List<SelectedAnswValue> SelectedAnsws { get; set; }
    }
}

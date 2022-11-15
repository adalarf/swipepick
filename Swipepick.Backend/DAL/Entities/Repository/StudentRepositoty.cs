using DAL.AppDBContext.SQL;
using DAL.Entities.Repository.Interfaces;


namespace DAL.Entities.Repository
{
    public class StudentRepositoty : AppDBContext<StudentDal, int>, IStudentRepository
    {
        public StudentRepositoty(DalSetting dalSetting) : base(dalSetting)
        {

        }
    }
}

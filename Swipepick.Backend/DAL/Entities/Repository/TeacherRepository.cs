using DAL.AppDBContext.SQL;
using DAL.Entities.Repository.Interfaces;

namespace DAL.Entities.Repository
{
    public class TeacherRepository : AppDBContext<TeacherDal, int>, ITeacherRepository
    {
        public TeacherRepository(DalSetting dalSetting) : base(dalSetting)
        {
        }
    }
}

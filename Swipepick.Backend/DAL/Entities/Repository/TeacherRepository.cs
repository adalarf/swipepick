using DAL.AppDBContext.SQL;

namespace DAL.Entities.Repository
{
    public class TeacherRepository : AppDBContext<TeacherDal, int>
    {
        public TeacherRepository(DalSetting dalSetting) : base(dalSetting)
        {
        }
    }
}

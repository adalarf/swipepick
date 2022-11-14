using DAL.Repository.Interfaces;
using System.Data;

namespace DAL.Entities.Repository.Interfaces
{
    public interface ITeacherRepository : IRepository<TeacherDal, int>
    {
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
    }
}

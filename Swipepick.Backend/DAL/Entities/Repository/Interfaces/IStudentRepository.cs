using Core.Dal.Repository.Interfaces;
using System.Data;


namespace DAL.Entities.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<StudentDal, int>
    {
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
    }
}

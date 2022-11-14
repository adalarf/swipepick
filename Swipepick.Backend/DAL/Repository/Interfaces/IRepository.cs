using DAL.Entities.Repository.Interfaces;
using System.Data;

namespace DAL.Repository.Interfaces
{
    internal interface IRepository<TModel, in TType> : IDisposable
        where TModel : IDalModel<TType>
    {
        IEnumerable<TModel> GetAll(IDbTransaction transaction = null);
        TModel GetItem(TType id);
        void Create(TModel item); 
        void Update(TModel item);
        void Delete(TType id); 
        void Save();
    }
}

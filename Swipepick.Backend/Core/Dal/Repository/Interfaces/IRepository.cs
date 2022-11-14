using Core.Dal.Repository.Interfaces.Model;
using System.Data;

namespace Core.Dal.Repository.Interfaces
{
    /// <summary>
    /// Общий интерфейс для всех классов, инкапсулирующий работу с ORM
    /// </summary>
    /// <typeparam name="TModel">Модель, описывающая структуру данных</typeparam>
    /// <typeparam name="TType">Тип первичного ключа</typeparam>
    public interface IRepository<TModel, in TType> : IDisposable
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

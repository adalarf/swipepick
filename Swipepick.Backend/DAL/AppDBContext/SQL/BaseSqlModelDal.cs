using Core.Dal.Repository.Interfaces.Model;

namespace DAL.AppDBContext.SQL
{
    /// <summary>
    /// Базовая сущность для всех SQL моделей
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public abstract class BaseSqlModelDal<TType> : IDalModel<TType>
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public TType Id { get; init; }
    }
}

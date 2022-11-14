using Core.Dal.Repository.Interfaces.Model;

namespace DAL.AppDBContext.SQL
{
    public class BaseSqlModelDal<TType> : IDalModel<TType>
    {
        public TType Id { get; init; }
    }
}



namespace Core.Dal.Repository.Interfaces.Model
{
    public interface IDalModel<TType>
    {
        public TType Id { get; init; }
    }
}

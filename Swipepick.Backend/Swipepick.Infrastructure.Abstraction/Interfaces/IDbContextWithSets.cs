using Microsoft.EntityFrameworkCore;

namespace Swipepick.Infrastructure.Abstraction.Interfaces;

public interface IDbContextWithSets
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

using UA.Data.Core.Configuration;
using UA.Data.Models.Base;

namespace UA.Data.Repositories.Interfaces;

public interface IKeyedRepository<TId, TEntity>
    where TEntity : Entity<TId>
    where TId : struct
{
    Task<TEntity> GetByIdAsync(TId id, Configuration<TEntity> configuration = null);
}
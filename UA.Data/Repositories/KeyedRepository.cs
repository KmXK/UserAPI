using Microsoft.EntityFrameworkCore;
using UA.Data.Core.Configuration;
using UA.Data.Helpers;
using UA.Data.Models.Base;

namespace UA.Data.Repositories;

public class KeyedRepository<TId, TEntity> : Repository<TEntity>
    where TEntity : Entity<TId>
    where TId : struct
{
    protected KeyedRepository(AppContext context) : base(context)
    {
    }

    public async Task<TEntity> GetByIdAsync(TId id, Configuration<TEntity> configuration = null)
    {
        return await Queryable.Apply(configuration).FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
}
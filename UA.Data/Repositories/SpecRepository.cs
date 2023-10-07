using LinqSpecs;
using Microsoft.EntityFrameworkCore;
using UA.Data.Core.Configuration;
using UA.Data.Helpers;
using UA.Data.Models.Base;

namespace UA.Data.Repositories;

public class SpecRepository<TEntity> : Repository<TEntity> where TEntity : Entity
{
    protected SpecRepository(AppContext context) : base(context)
    {
    }

    public async Task<TEntity> GetBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null)
    {
        return await Queryable
            .ApplySpecification(specification)
            .ApplyConfiguration(configuration)
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<TEntity>> GetListBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null)
    {
        return await Queryable
            .ApplySpecification(specification)
            .ApplyConfiguration(configuration)
            .ToListAsync();
    }
}
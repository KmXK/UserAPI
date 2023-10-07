using LinqSpecs;
using Microsoft.EntityFrameworkCore;
using UA.Data.Core.Configuration;
using UA.Data.Helpers;
using UA.Data.Models.Base;
using UA.Data.Repositories.Interfaces;

namespace UA.Data.Repositories;

internal class SpecRepository<TEntity> : Repository<TEntity>, ISpecRepository<TEntity>
    where TEntity : Entity
{
    internal SpecRepository(AppContext context) : base(context)
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
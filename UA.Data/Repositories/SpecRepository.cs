using LinqSpecs;
using Microsoft.EntityFrameworkCore;
using UA.Data.Core.Configuration;
using UA.Data.Core.Pagination;
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

    public async Task<PageModel<TEntity>> GetPagedListBySpecAsync(
        PageFilterModel<TEntity> pageFilterModel,
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null)
    {
        var items = Queryable
            .ApplySpecification(specification)
            .ApplyConfiguration(configuration)
            .ApplySorting(pageFilterModel.Sorting);

        var totalCount = await items.CountAsync();

        if (pageFilterModel.PageSize.HasValue)
        {
            items = items
                .Skip(pageFilterModel.PageSize.Value * pageFilterModel.PageIndex)
                .Take(pageFilterModel.PageSize.Value);
        }

        return new PageModel<TEntity>(
            totalCount,
            await items.ToListAsync()
        );
    }

    public async Task<bool> Exists(Specification<TEntity> specification)
    {
        return await Queryable.ApplySpecification(specification).AnyAsync();
    }
}
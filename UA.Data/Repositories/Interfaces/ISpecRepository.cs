using LinqSpecs;
using UA.Data.Core.Configuration;
using UA.Data.Core.Pagination;
using UA.Data.Models.Base;

namespace UA.Data.Repositories.Interfaces;

public interface ISpecRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    Task<TEntity> GetBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null);

    Task<IEnumerable<TEntity>> GetListBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null);

    Task<PageModel<TEntity>> GetPagedListBySpecAsync(
        PageFilterModel<TEntity> pageFilterModel,
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null);

    Task<int> DeleteBySpecAsync(Specification<TEntity> specification);

    Task<bool> Exists(Specification<TEntity> specification);
}
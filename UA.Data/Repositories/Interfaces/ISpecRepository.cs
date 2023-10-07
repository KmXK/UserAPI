using LinqSpecs;
using UA.Data.Core.Configuration;
using UA.Data.Models.Base;

namespace UA.Data.Repositories.Interfaces;

public interface ISpecRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null);

    Task<IEnumerable<TEntity>> GetListBySpecAsync(
        Specification<TEntity> specification,
        Configuration<TEntity> configuration = null);
}
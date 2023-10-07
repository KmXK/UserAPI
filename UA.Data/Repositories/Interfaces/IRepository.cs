using UA.Data.Core.Configuration;
using UA.Data.Models.Base;

namespace UA.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync(Configuration<TEntity> configuration = null);

    Task<bool> AddAsync(TEntity entity);

    bool Update(TEntity entity);

    bool Delete(TEntity entity);
}
using UA.Data.Models.Base;
using UA.Data.Repositories.Interfaces;

namespace UA.Data.Core.Interfaces;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
    
    IKeyedRepository<TId, TEntity> GetKeyedRepository<TId, TEntity>()
        where TEntity : Entity<TId>
        where TId : struct;
    
    ISpecRepository<TEntity> GetSpecRepository<TEntity>() where TEntity : Entity;

    Task<int> SaveChangesAsync();
}
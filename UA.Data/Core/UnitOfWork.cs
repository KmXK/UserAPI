using UA.Data.Core.Interfaces;
using UA.Data.Models.Base;
using UA.Data.Repositories;
using UA.Data.Repositories.Interfaces;

namespace UA.Data.Core;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppContext _context;

    public UnitOfWork(AppContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
    {
        return new Repository<TEntity>(_context);
    }

    public IKeyedRepository<TId, TEntity> GetKeyedRepository<TId, TEntity>()
        where TId : struct where TEntity : Entity<TId>
    {
        return new KeyedRepository<TId, TEntity>(_context);
    }

    public ISpecRepository<TEntity> GetSpecRepository<TEntity>() where TEntity : Entity
    {
        return new SpecRepository<TEntity>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
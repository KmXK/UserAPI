using Microsoft.EntityFrameworkCore;
using UA.Data.Core.Configuration;
using UA.Data.Helpers;
using UA.Data.Models.Base;
using UA.Data.Repositories.Interfaces;

namespace UA.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppContext _context;
    private readonly DbSet<TEntity> _set;
    
    protected Repository(AppContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    protected IQueryable<TEntity> Queryable => _set.AsQueryable();
    
    public async Task<IEnumerable<TEntity>> GetAllAsync(Configuration<TEntity> configuration = null)
    {
        return await Queryable.ApplyConfiguration(configuration).ToListAsync();
    }

    public async Task<bool> AddAsync(TEntity entity)
    {
        var result = await _set.AddAsync(entity);
        
        return result.State == EntityState.Added;
    }
    
    public bool Update(TEntity entity)
    {
        _set.Update(entity);

        return _context.Entry(entity).State == EntityState.Modified;
    }
    
    public bool Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _set.Attach(entity);

        _set.Remove(entity);

        return _context.Entry(entity).State == EntityState.Deleted;
    }
}
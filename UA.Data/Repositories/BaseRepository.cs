using Microsoft.EntityFrameworkCore;
using UA.Data.Models.Base;

namespace UA.Data.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : Entity
{
    private readonly AppContext _context;
    
    protected BaseRepository(AppContext context)
    {
        _context = context;
        Set = _context.Set<TEntity>();
    }
    
    protected DbSet<TEntity> Set { get; }

    public async Task<bool> AddAsync(TEntity entity)
    {
        var result = await Set.AddAsync(entity);
        
        return result.State == EntityState.Added;
    }
    
    public bool Update(TEntity entity)
    {
        Set.Update(entity);

        return _context.Entry(entity).State == EntityState.Modified;
    }
    
    public bool Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            Set.Attach(entity);

        Set.Remove(entity);

        return _context.Entry(entity).State == EntityState.Deleted;
    }
}
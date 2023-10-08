using UA.Data.Core.Interfaces;
using UA.Data.Models.Base;
using UA.Data.Repositories.Interfaces;

namespace UA.Domain.Services.Base;

public abstract class BaseService<TId, TEntity> : BaseService
    where TEntity : Entity<TId>
    where TId : struct
{
    protected BaseService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected IKeyedRepository<TId, TEntity> WorkRepository => UnitOfWork.GetKeyedRepository<TId, TEntity>();
}
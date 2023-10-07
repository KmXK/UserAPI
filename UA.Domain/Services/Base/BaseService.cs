using UA.Data.Core.Interfaces;

namespace UA.Domain.Services.Base;

public abstract class BaseService
{
    protected IUnitOfWork UnitOfWork { get; }

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}
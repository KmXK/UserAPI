using UA.Data.Core.Interfaces;

namespace UA.Domain.Services.Base;

public abstract class BaseService
{
    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected IUnitOfWork UnitOfWork { get; }
}
namespace UA.Application.ViewModels.Pagination;

public record PageViewModel<TEntity>(
    int TotalCount,
    IEnumerable<TEntity> Data);
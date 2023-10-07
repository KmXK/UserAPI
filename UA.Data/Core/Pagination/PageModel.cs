namespace UA.Data.Core.Pagination;

public record PageModel<TEntity>(
    int TotalCount,
    IEnumerable<TEntity> Data);
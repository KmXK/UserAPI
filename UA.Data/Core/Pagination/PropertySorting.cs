using System.Linq.Expressions;
using UA.Data.Models.Base;

namespace UA.Data.Core.Pagination;

public record PropertySorting<TEntity>(
    SortDirection SortDirection,
    Expression<Func<TEntity, object>> PropertySelector) where TEntity : Entity;
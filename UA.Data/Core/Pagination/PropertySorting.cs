using System.Linq.Expressions;

namespace UA.Data.Core.Pagination;

public class PropertySorting<TEntity>
{
    public SortDirection SortDirection { get; set; }
    
    public Expression<Func<TEntity, object>> PropertySelector { get; set; }
}
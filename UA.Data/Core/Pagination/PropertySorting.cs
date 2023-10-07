using System.Linq.Expressions;
using UA.Data.Models.Base;

namespace UA.Data.Core.Pagination;

public class PropertySorting<TEntity> where TEntity : Entity
{
    public SortDirection SortDirection { get; set; }
    
    public Expression<Func<TEntity, object>> PropertySelector { get; set; }
}
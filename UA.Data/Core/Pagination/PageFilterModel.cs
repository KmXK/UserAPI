using UA.Data.Models.Base;

namespace UA.Data.Core.Pagination;

public class PageFilterModel<TEntity> where TEntity : Entity
{
    public int PageIndex { get; set; }
    
    public int? PageSize { get; set; }
    
    public PropertySorting<TEntity> Sorting { get; set; }
}
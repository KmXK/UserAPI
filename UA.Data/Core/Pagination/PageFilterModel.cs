namespace UA.Data.Core.Pagination;

public class PageFilterModel<TEntity>
{
    public int PageIndex { get; set; }
    
    public int? PageSize { get; set; }
    
    public PropertySorting<TEntity> Sorting { get; set; }
}
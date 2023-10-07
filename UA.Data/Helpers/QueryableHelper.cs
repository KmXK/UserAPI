using System.Formats.Tar;
using LinqSpecs;
using Microsoft.VisualBasic.CompilerServices;
using UA.Data.Core.Configuration;
using UA.Data.Core.Pagination;
using UA.Data.Models.Base;

namespace UA.Data.Helpers;

internal static class QueryableHelper
{
    public static IQueryable<TEntity> ApplyConfiguration<TEntity>(
        this IQueryable<TEntity> queryable,
        Configuration<TEntity> configuration) where TEntity : Entity
    {
        if (configuration is null)
        {
            return queryable;
        }

        return configuration.Apply(queryable);
    } 
    
    public static IQueryable<TEntity> ApplySpecification<TEntity>(
        this IQueryable<TEntity> queryable,
        Specification<TEntity> specification) where TEntity : Entity
    {
        if (specification is null)
        {
            return queryable;
        }

        return queryable.Where(specification.ToExpression());
    }

    public static IQueryable<TEntity> ApplySorting<TEntity>(
        this IQueryable<TEntity> queryable,
        PropertySorting<TEntity> sorting) where TEntity : Entity
    {
        if (sorting is null)
        {
            return queryable;
        }

        queryable = sorting.SortDirection switch
        {
            SortDirection.Ascending => queryable.OrderBy(sorting.PropertySelector),
            SortDirection.Descending => queryable.OrderByDescending(sorting.PropertySelector),
            _ => throw new ArgumentOutOfRangeException(nameof(sorting))
        };

        return queryable;
    }
}
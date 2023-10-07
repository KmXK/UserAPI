using LinqSpecs;
using UA.Data.Core.Configuration;
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
}
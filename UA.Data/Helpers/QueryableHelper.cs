using UA.Data.Core.Configuration;
using UA.Data.Models.Base;

namespace UA.Data.Helpers;

internal static class QueryableHelper
{
    public static IQueryable<TEntity> Apply<TEntity>(
        this IQueryable<TEntity> queryable,
        Configuration<TEntity> configuration) where TEntity : Entity
    {
        if (configuration is null)
        {
            return queryable;
        }

        return configuration.Apply(queryable);
    } 
}
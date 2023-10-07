using System.Linq.Expressions;
using UA.Data.Models.Base;

namespace UA.Data.Core.Configuration;

public static class ConfigurationBuilder
{
    public static Configuration<TEntity> Build<TEntity>(
        params Expression<Func<TEntity, object>>[] includes
    ) where TEntity : Entity
    {
        var configuration = new Configuration<TEntity>();

        foreach (var include in includes)
        {
            configuration.Add(include);
        }

        return configuration;
    }

    public static Configuration<TEntity> Build<TEntity>(
        IEnumerable<Expression<Func<TEntity, object>>> includes
    ) where TEntity : Entity
    {
        return Build(includes.ToArray());
    }
}
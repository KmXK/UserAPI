using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UA.Data.Models.Base;

namespace UA.Data.Core.Configuration;

public sealed class Configuration<TEntity> where TEntity : Entity
{
    private readonly List<Expression<Func<TEntity, object>>> _includeList = new();

    public void Add(Expression<Func<TEntity, object>> include)
    {
        _includeList.Add(include);
    }

    public IQueryable<TEntity> Apply(IQueryable<TEntity> query)
    {
        return _includeList.Aggregate(query, (current, include) => current.Include(GetIncludeAsString(include)));
    }

    private static string GetIncludeAsString(Expression include)
    {
        var lambdaExpression = include as LambdaExpression;

        var expression = lambdaExpression.Body;

        var list = new List<string>();

        while (expression is not null)
        {
            if (expression is MemberExpression me)
            {
                list.Add(me.Member.Name);

                expression = me.Expression;
            }
            else if (expression is MethodCallExpression mc)
            {
                if (mc.Method.Name != nameof(Enumerable.Select))
                {
                    throw new InvalidOperationException("Invalid method call found.");
                }

                var arg = mc.Arguments[1] as LambdaExpression;
                list.Add(GetIncludeAsString(arg));

                expression = mc.Arguments[0];
            }
            else
            {
                break;
            }
        }
        
        list.Reverse();
        return string.Join('.', list);
    }
}
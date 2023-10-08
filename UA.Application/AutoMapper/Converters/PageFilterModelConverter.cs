using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using UA.Application.ViewModels.Pagination;
using UA.Data.Core.Pagination;

namespace UA.Application.AutoMapper.Converters;

public class PageFilterModelConverter<TEntity> : ITypeConverter<PageFilterViewModel, PageFilterModel<TEntity>>
{
    public PageFilterModel<TEntity> Convert(
        PageFilterViewModel pageFilterViewModel,
        PageFilterModel<TEntity> pageFilterModel,
        ResolutionContext context)
    {
        var modelType = typeof(TEntity);

        const BindingFlags bindingFlags = BindingFlags.Public
                                          | BindingFlags.Instance
                                          | BindingFlags.GetProperty
                                          | BindingFlags.IgnoreCase;

        if (pageFilterViewModel.Sorting == null)
        {
            return new PageFilterModel<TEntity>
            {
                PageIndex = pageFilterViewModel.PageIndex,
                PageSize = pageFilterViewModel.PageSize
            };
        }

        var selectorParameter = Expression.Parameter(modelType);
        var propertySelector = Expression.Lambda<Func<TEntity, object>>(
            Expression.Convert(
                Expression.MakeMemberAccess(
                    selectorParameter,
                    modelType.GetProperty(
                        pageFilterViewModel.Sorting.PropertyName,
                        bindingFlags)!
                ),
                typeof(object)),
            selectorParameter);

        return new PageFilterModel<TEntity>
        {
            PageIndex = pageFilterViewModel.PageIndex,
            PageSize = pageFilterViewModel.PageSize,
            Sorting = new PropertySorting<TEntity>
            {
                SortDirection = pageFilterViewModel.Sorting.SortDirection,
                PropertySelector = propertySelector
            }
        };
    }
}
using System.Linq.Expressions;
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

        pageFilterModel.PageIndex = pageFilterViewModel.PageIndex;
        pageFilterModel.PageSize = pageFilterViewModel.PageSize;

        pageFilterModel.Sorting.SortDirection = pageFilterViewModel.Sorting.SortDirection;

        var selectorParameter = Expression.Parameter(modelType);
        var propertySelector = Expression.Lambda(
            Expression.MakeMemberAccess(
                selectorParameter,
                modelType.GetProperty(pageFilterViewModel.Sorting.PropertyName)!
            ),
            selectorParameter);

        pageFilterModel.Sorting.PropertySelector = propertySelector as Expression<Func<TEntity, object>>;

        return pageFilterModel;
    }
}
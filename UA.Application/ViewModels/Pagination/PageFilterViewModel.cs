namespace UA.Application.ViewModels.Pagination;

public record PageFilterViewModel(
    int PageIndex,
    int? PageSize,
    PropertySortingViewModel Sorting);
using UA.Data.Core.Pagination;

namespace UA.Application.ViewModels.Pagination;

public record PropertySortingViewModel(
    string PropertyName,
    SortDirection SortDirection);
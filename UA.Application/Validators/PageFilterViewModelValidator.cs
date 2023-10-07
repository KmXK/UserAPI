using System.Data;
using FluentValidation;
using UA.Application.ViewModels.Pagination;

namespace UA.Application.Validators;

public class PageFilterViewModelValidator : AbstractValidator<PageFilterViewModel>
{
    public PageFilterViewModelValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page index must be positive integer.");
        
        RuleFor(x => x.PageSize)
            .Must(x => x.HasValue == false || x >= 1)
            .WithMessage("Page size must be positive integer.");

        RuleFor(x => x.Sorting)
            .NotNull().WithMessage("Sorting is required for pagination.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Sorting.SortDirection)
                    .IsInEnum().WithMessage("Invalid sort direction value.");

                RuleFor(x => x.Sorting.PropertyName)
                    .NotEmpty().WithMessage("Invalid sorting property name.");
            });
    }
}
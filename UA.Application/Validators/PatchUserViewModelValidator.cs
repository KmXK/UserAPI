using FluentValidation;
using UA.Application.ViewModels;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Validators;

public class PatchUserViewModelValidator : AbstractValidator<PatchUserViewModel>
{
    public PatchUserViewModelValidator(
        IUserService userService)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Age)
            .Must(a => a > 0).WithMessage("Age must be positive integer.")
            .When(x => x.Age.HasValue);

        RuleFor(x => x.Roles)
            .NotEmpty().WithMessage("User must have at least one role.")
            .When(x => x.Roles != null);

        When(x => x.Email != null, () =>
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email.")
                .MustAsync(async (model, _, _) =>
                    await userService.DoesUserWithEmailExist(model.Email, model.Id) == false)
                .WithMessage("User with such email already exists."));
    }
}
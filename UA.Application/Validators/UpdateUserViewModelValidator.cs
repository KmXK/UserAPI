using FluentValidation;
using UA.Application.ViewModels;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Validators;

public class UpdateUserViewModelValidator : AbstractValidator<UpdateUserViewModel>
{
    public UpdateUserViewModelValidator(
        IUserService userService)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Age)
            .NotEmpty().WithMessage("Age is required.")
            .Must(a => a > 0).WithMessage("Age must be positive integer.");

        RuleFor(x => x.Roles)
            .NotEmpty().WithMessage("User must have at least one role.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email.")
            .MustAsync(async (model, _, _) => await userService.DoesUserWithEmailExist(model.Email, model.Id) == false)
            .WithMessage("User with such email already exists.");
    }
}
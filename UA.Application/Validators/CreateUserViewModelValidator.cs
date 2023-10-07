using FluentValidation;
using UA.Application.ViewModels;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Validators;

public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
{
    public CreateUserViewModelValidator(
        IUserService userService)
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email.")
            .MustAsync(async (email, _) => await userService.DoesUserWithEmailExist(email) == false)
            .WithMessage("User with such email already exists.");
        
        RuleFor(x => x.Age)
            .Must(a => a > 0).WithMessage("Age must be positive integer.");
        
        RuleFor(x => x.Roles)
            .NotEmpty().WithMessage("User must have at least one role.");
    }
}
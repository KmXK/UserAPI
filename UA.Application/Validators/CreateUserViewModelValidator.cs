using FluentValidation;
using UA.Application.ViewModels;
using UA.Domain.Services.Interfaces;

namespace UA.Application.Validators;

public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
{
    public CreateUserViewModelValidator(
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
            .MustAsync(async (email, _) => await userService.DoesUserWithEmailExist(email) == false)
            .WithMessage("User with such email already exists.");
    }
}
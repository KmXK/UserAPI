using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UA.Application.ViewModels;

namespace UA.Web.Filters;

public sealed class ValidationFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var errors = validationException.Errors.Select(e =>
                new ValidationErrorViewModel(
                    e.PropertyName,
                    e.ErrorMessage));
            
            context.Result = new BadRequestObjectResult(new {errors});
            context.ExceptionHandled = true;
        }

        return Task.CompletedTask;
    }
}
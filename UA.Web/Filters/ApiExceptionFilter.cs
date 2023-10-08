using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UA.Application.ViewModels;

namespace UA.Web.Filters;

public sealed class ApiExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var errors = context.Exception switch
        {
            ValidationException ex => ex
                .Errors
                .Select(x => new ErrorViewModel(x.PropertyName, x.ErrorMessage))
                .ToList(),
            _ => context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => new ErrorViewModel(e.ErrorMessage))
                .ToList()
        };
        
        if (!errors.Any())
        {
            errors.Add(new ErrorViewModel(context.Exception.Message));
        }

        context.Result = new BadRequestObjectResult(new { errors });
        context.ExceptionHandled = true;

        return Task.CompletedTask;
    }
}
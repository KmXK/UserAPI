using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using IValidator = UA.Application.Validators.Interfaces.IValidator;

namespace UA.Application.Validators;

public sealed class Validator : IValidator
{
    private readonly IServiceProvider _serviceProvider;

    public Validator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task Validate<TModel>(TModel model)
    {
        var validator =  _serviceProvider.GetService<IValidator<TModel>>();
        await validator.ValidateAndThrowAsync(model);
    }
}
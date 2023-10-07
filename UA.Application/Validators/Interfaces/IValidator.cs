using FluentValidation.Results;

namespace UA.Application.Validators.Interfaces;

public interface IValidator
{
    Task Validate<TModel>(TModel model);
}
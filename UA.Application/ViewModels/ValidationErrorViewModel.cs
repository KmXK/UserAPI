namespace UA.Application.ViewModels;

public record ValidationErrorViewModel(
    string PropertyName,
    string Message);
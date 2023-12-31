﻿namespace UA.Application.ViewModels;

public class ErrorViewModel
{
    public ErrorViewModel(string message) : this(null, message)
    {
    }

    public ErrorViewModel(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }

    public string PropertyName { get; init; }
    
    public string Message { get; init; }
}
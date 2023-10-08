namespace UA.Domain.Exceptions;

public class DomainViolationException : Exception
{
    public DomainViolationException(string message) : base(message)
    {
    }
}
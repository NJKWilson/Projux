namespace Projux.Backend.Core.BasicServices.CustomerContact.Exceptions;

public class CustomerContactServiceValidationException : Exception
{
    public CustomerContactServiceValidationException(string message)
        : base(message) {}
}

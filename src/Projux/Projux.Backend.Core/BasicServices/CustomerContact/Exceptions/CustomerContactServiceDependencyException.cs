namespace Projux.Backend.Core.BasicServices.CustomerContact.Exceptions;

public class CustomerContactServiceDependencyException : Exception
{
    public CustomerContactServiceDependencyException(string message, Exception inner)
        : base(message, inner) {}
}

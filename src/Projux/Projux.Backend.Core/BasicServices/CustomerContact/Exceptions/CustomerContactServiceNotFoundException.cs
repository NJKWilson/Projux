namespace Projux.Backend.Core.BasicServices.CustomerContact.Exceptions;

public class CustomerContactServiceNotFoundException : Exception
{
    public CustomerContactServiceNotFoundException(string message)
        : base(message) { }
}

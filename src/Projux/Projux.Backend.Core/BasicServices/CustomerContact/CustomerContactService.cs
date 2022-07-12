using LiteDB;
using Projux.Backend.Core.BasicServices.CustomerContact.Exceptions;
using Projux.Backend.Core.Database;
using Projux.Backend.Core.Database.Entities;

namespace Projux.Backend.Core.BasicServices.CustomerContact;

public class CustomerContactService : ICustomerContactService
{
    private readonly LiteDatabase _liteDb;

    public CustomerContactService(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
    }

    public bool Delete(ObjectId id)
    {
        return GetCollection().Delete(id);
    }

    public IEnumerable<CustomerContactEntity> FindAll()
    {
        return GetCollection().FindAll();
    }

    public CustomerContactEntity FindById(ObjectId id)
    {
        // Validate input
        if (id == ObjectId.Empty)
            throw new CustomerContactServiceValidationException("Id cannot be empty");

        CustomerContactEntity customer;

        // Try to get the customer from the database
        try
        {
            customer = GetCollection().FindById(id);
        }
        catch (Exception exception)
        {
            throw new CustomerContactServiceDependencyException("Unknown dependancy exception see inner exception", exception);
        }
        
        // Check if the customer is null
        if (customer == null)
            throw new CustomerContactServiceNotFoundException($"Customer with Id: {id} was not found in the database.");

        return customer;

        //return GetCollection().Find(x => x.Id == id).FirstOrDefault();
    }

    public ObjectId Insert(CustomerContactEntity customerContact)
    {
        // Validate input
        if (string.IsNullOrEmpty(customerContact.FirstName))
            throw new CustomerContactServiceValidationException("First name cannot be empty");
        if (string.IsNullOrEmpty(customerContact.LastName))
            throw new CustomerContactServiceValidationException("Last name cannot be empty");
        if (string.IsNullOrEmpty(customerContact.EmailAddress))
            throw new CustomerContactServiceValidationException("Email address cannot be empty");
        if (string.IsNullOrEmpty(customerContact.PhoneNumber))
            throw new CustomerContactServiceValidationException("Phone number cannot be empty");

        ObjectId result;

        // Try to insert the customer to the database
        try
        {
            result = GetCollection().Insert(customerContact);
        }
        catch (LiteException exception) when (exception.Message.Contains("Cannot insert duplicate key in unique index '_id'."))
        {
            throw new CustomerContactServiceDependencyException($"A customer contact with the id:{customerContact.Id} already exists.", exception);
        }
        catch (Exception exception)
        {
            throw new CustomerContactServiceDependencyException("Unknown dependancy exception see inner exception", exception);
        }
        
        return result;
    }

    public bool Update(CustomerContactEntity customerContact)
    {
        return GetCollection().Update(customerContact);
    }

    private ILiteCollection<CustomerContactEntity> GetCollection()
    {
        return _liteDb.GetCollection<CustomerContactEntity>("CustomerContact");
    }
}

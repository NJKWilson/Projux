namespace Projux.Backend.Core.BasicServices.CustomerContact;

using Projux.Backend.Core.Database.Entities;
using LiteDB;

public interface ICustomerContactService
{
    IEnumerable<CustomerContact> FindAll();
    CustomerContact FindById(ObjectId id);
    ObjectId Insert(CustomerContact customerContact);
    bool Update(CustomerContact customerContact);
    bool Delete(ObjectId id);
}

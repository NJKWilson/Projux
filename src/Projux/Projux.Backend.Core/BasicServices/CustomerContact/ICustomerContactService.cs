using Projux.Backend.Core.Database.Entities;
using LiteDB;

namespace Projux.Backend.Core.BasicServices.CustomerContact;

public interface ICustomerContactService
{
    IEnumerable<CustomerContactEntity> FindAll();
    CustomerContactEntity FindById(ObjectId id);
    ObjectId Insert(CustomerContactEntity customerContact);
    bool Update(CustomerContactEntity customerContact);
    bool Delete(ObjectId id);
}

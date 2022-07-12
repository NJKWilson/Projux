using Projux.Backend.Core.Tests.Fixtures.Collection.LiteDbContext;
using Projux.Backend.Core.BasicServices.CustomerContact;
using LiteDB;
using Projux.Backend.Core.BasicServices.CustomerContact.Exceptions;
using Projux.Backend.Core.Database.Entities;

namespace Projux.Backend.Core.Tests.BasicServices.CustomerContact;

[Collection("LiteDbContextCollection")]
public class CustomerContactServiceTests
{
    private readonly LiteDbContextFixture _liteDbContextFixture;
    private readonly ICustomerContactService _customerContactService;

    public CustomerContactServiceTests(LiteDbContextFixture liteDbContextFixture)
    {
        _liteDbContextFixture = liteDbContextFixture;
        _customerContactService = new CustomerContactService(_liteDbContextFixture.Db);
    }

    [Fact]
    public void FindById_UsingRandomId_ShouldThrowException()
    {
        var randomId = ObjectId.NewObjectId();
        Assert.Throws<CustomerContactServiceNotFoundException>(() => _customerContactService.FindById(randomId));
    }

    [Fact]
    public void FindById_UsingBlankId_ShouldThrowException()
    {
        var blankId = ObjectId.Empty;
        Assert.Throws<CustomerContactServiceValidationException>(() => _customerContactService.FindById(blankId));
    }


    [Fact]
    public void Insert_RandomCustomer_ShouldReturnVailidObjectId()
    {
        var customerContact = new CustomerContactEntity
        {
            FirstName = ObjectId.NewObjectId().ToString(),
            LastName = ObjectId.NewObjectId().ToString(),
            EmailAddress = ObjectId.NewObjectId().ToString(),
            PhoneNumber = ObjectId.NewObjectId().ToString()
        };

        var result = _customerContactService.Insert(customerContact);
        Assert.NotNull(result);
    }

    [Fact]
    public void Insert_TwoSameIdo_ShouldDoSomething()
    {
        var customerContact = new CustomerContactEntity
        {
            Id = ObjectId.NewObjectId(),
            FirstName = ObjectId.NewObjectId().ToString(),
            LastName = ObjectId.NewObjectId().ToString(),
            EmailAddress = ObjectId.NewObjectId().ToString(),
            PhoneNumber = ObjectId.NewObjectId().ToString()
        };

        var result1 = _customerContactService.Insert(customerContact);
        Assert.Throws<CustomerContactServiceDependencyException>(() => _customerContactService.Insert(customerContact));
    }
}

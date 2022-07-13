using Grpc.Core;
using Projux.Backend.Core.BasicServices.CustomerContact;
using Projux.Backend.Core.Database.Entities;

namespace Projux.Backend.gRPC.Services;

public class CustomerContactGrpcService : CustomerContact.CustomerContactBase
{
    private readonly ICustomerContactService _customerContactService;

    public CustomerContactGrpcService(ICustomerContactService customerContactService)
    {
        _customerContactService = customerContactService;
    }

    public override Task<InsertReply> Insert(InsertRequest request, ServerCallContext context)
    {
        CustomerContactEntity customerContactEntity = new CustomerContactEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber,
        };

        InsertReply insertReply = new InsertReply();

        string result = "";

        try
        {
            insertReply.Id = _customerContactService.Insert(customerContactEntity).ToString();
            insertReply.Successful = true;
        }
        catch (Exception exception)
        {
            insertReply.Successful = false;
            insertReply.ErrorMessage = exception.Message;
        }

        return Task.FromResult(insertReply);
    }

    public override Task<UpdateReply> Update(UpdateRequest request, ServerCallContext context)
    {
        return base.Update(request, context);
    }

    public override Task<FindByIdReply> FindById(FindByIdRequest request, ServerCallContext context)
    {
        return base.FindById(request, context);
    }

    public override Task<FindAllReply> FindAll(FindAllRequest request, ServerCallContext context)
    {
        return base.FindAll(request, context);
    }

    public override Task<DeleteByIdReply> DeleteById(DeleteByIdRequest request, ServerCallContext context)
    {
        return base.DeleteById(request, context);
    }
}

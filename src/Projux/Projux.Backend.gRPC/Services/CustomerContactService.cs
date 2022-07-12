using Grpc.Core;

namespace Projux.Backend.gRPC.Services;

public class CustomerContactService : CustomerContact.CustomerContactBase
{
    public override Task<InsertReply> Insert(InsertRequest request, ServerCallContext context)
    {
        return base.Insert(request, context);
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

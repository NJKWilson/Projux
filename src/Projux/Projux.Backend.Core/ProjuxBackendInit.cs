namespace Projux.Backend.Core;

using Microsoft.Extensions.DependencyInjection;
using Projux.Backend.Core.BasicServices.CustomerContact;
using Projux.Backend.Core.Database;

public static class ProjuxBackendInit
{
    public static void AddProjuxBackendCore(this IServiceCollection serviceCollection, string dbLocation)
    {
        // Services
        var liteDbOptions = new LiteDbOptions { DatabaseLocation = dbLocation };

        serviceCollection.AddSingleton(liteDbOptions);
        serviceCollection.AddSingleton<ILiteDbContext, LiteDbContext>();
        serviceCollection.AddTransient<ICustomerContactService, CustomerContactService>();
    }
}

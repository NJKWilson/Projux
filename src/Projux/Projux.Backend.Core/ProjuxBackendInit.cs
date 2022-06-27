using Microsoft.Extensions.DependencyInjection;
using Projux.Backend.Core.Database;

namespace Projux.Backend.Core
{
    public static class ProjuxBackendInit
    {
        public static void AddProjuxBackendCore(this IServiceCollection serviceCollection, string dbLocation)
        {
            // Services
            var liteDbOptions = new LiteDbOptions { DatabaseLocation = dbLocation };

            serviceCollection.AddSingleton(liteDbOptions);
            serviceCollection.AddSingleton<ILiteDbContext, LiteDbContext>();
        }
    }
}

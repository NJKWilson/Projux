using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Projux.UI.Core
{
    public static class ProjectCoreInit
    {
        public static void AddProjuxCore(this IServiceCollection serviceCollection)
        {
            // Services
            serviceCollection.AddMudServices();
        }
    }
}

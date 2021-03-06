using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Projux.UI.WPF.Data;

namespace Projux.UI.Core
{
    public static class ProjectCoreInit
    {
        public static void AddProjuxCore(this IServiceCollection serviceCollection)
        {
            // Services
            serviceCollection.AddMudServices();
            serviceCollection.AddSingleton<WeatherForecastService>();
        }
    }
}

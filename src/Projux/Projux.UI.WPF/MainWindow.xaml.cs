using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Projux.UI.Core;
using Projux.UI.WPF.Data;

namespace Projux.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddProjuxCore();
            serviceCollection.AddSingleton<WeatherForecastService>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}

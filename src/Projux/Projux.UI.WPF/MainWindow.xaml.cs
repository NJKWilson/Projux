using System.Windows;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Projux.UI.Core;
using Projux.UI.WPF.Data;
using Projux.UI.WPF.Pages;

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
            

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}

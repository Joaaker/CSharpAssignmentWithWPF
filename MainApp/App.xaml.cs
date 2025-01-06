using System.Windows;
using MainApp.ViewModels;
using MainApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MainApp;


public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<AddContactViewModel>();
                services.AddTransient<AddContactView>();

                services.AddTransient<EditContactViewModel>();
                services.AddTransient<EditContactView>();

                services.AddTransient<ListContactsViewModel>();
                services.AddTransient<ListContactsView>();

            })
            .Build();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

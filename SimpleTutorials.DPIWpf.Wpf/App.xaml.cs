using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SimpleTutorials.DPIWpf.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    
    /// <summary>
    /// Hôte nécessaire à l'injection de dépendance
    /// </summary>
    public static IHost? AppHost { get; private set; }


    /// <summary>
    /// Constructeur par défaut. Initialise les services
    /// </summary>
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) => 
            {
                services.AddSingleton<MainWindow>();
            
            }).Build() ;

    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Démarrage de l'application
        await AppHost!.StartAsync();

        MainWindow? startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();


        base.OnStartup(e);
    }


    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}

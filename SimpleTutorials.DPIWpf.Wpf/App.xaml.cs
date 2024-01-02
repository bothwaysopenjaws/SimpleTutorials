using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTutorials.DPIWpf.DBLib;
using System.Configuration;
using System.Data;
using System.Windows;
using SimpleTutorials.DPIWpf.Wpf.StartupHelpers;


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
                services.AddTransient<IDataAccess, DataAccess>();
                services.AddFormFactory<ChildFormWindow>();
            
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

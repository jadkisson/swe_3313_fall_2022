using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeePointOfSale;

internal static class Program
{
    private static void SetupDisplay()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    }

    public static IServiceProvider? ServiceProvider { get; private set; }
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        SetupDisplay();

        SetupDependencyInjection();

        ApplicationConfiguration.Initialize();
        Application.Run(ServiceProvider!.GetRequiredService<MainForm>());
    }

    private static void SetupDependencyInjection()
    {
        //https://stackoverflow.com/a/70476716
        //how to setup DI for Winforms
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) => Startup.ConfigureServices(services));
    }
}
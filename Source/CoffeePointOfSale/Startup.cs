using CoffeePointOfSale.Configuration;
using CoffeePointOfSale.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoffeePointOfSale;

static class Startup
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureDependencies(serviceCollection);
        SetupConfiguration(serviceCollection);
    }

    private static void ConfigureDependencies(IServiceCollection services)
    {
        services.AddTransient<IHelloService, HelloService>();
        services.AddTransient<MainForm>();
        services.AddLogging(configure => configure.AddConsole());
    }

    private static void SetupConfiguration(IServiceCollection services)
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile(
                "appsettings.json", 
                optional: false, 
                reloadOnChange: true);
        var config = configBuilder.Build();
        var appSettings = config.Get<AppSettings>();
        services.AddSingleton(appSettings);
    }
}
using MarysCandyShop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Configure AppSettings from appsettings.json
        IConfiguration configuration = hostContext.Configuration;
        services.Configure<Configuration>(configuration.GetSection("AppSettings"));

        // Register IProductsController and ProductsController
        services.AddTransient<IProductsController, ProductsController>();
        services.AddTransient<UserInterface>();

    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Retrieve the configured AppSettings
    IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
    string con = config.GetSection("AppSettings:ConnectionString").Value;

    // Create an instance of UserInterface and let the dependency injection container inject IProductsController
    var userInterface = serviceProvider.GetRequiredService<UserInterface>();

    // Use UserInterface methods
    userInterface.RunMainMenu();

    await host.RunAsync();
}





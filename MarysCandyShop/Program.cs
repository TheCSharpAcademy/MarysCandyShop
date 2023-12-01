using MarysCandyShop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<Configuration>(configuration.GetSection("Configuration"));
        services.AddTransient<IProductsController, ProductsController>();
        services.AddTransient<UserInterface>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var userInterface = serviceProvider.GetRequiredService<UserInterface>();

    userInterface.RunMainMenu();

    await host.RunAsync();
}

//DataSeed.SeedData();

Console.WriteLine();




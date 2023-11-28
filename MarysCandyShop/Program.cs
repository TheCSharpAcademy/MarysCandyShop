using MarysCandyShop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
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




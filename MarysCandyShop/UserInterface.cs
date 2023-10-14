using Spectre.Console;
using System.Drawing;
using static MarysCandyShop.Enums;

namespace MarysCandyShop;

internal static class UserInterface
{
    internal const string divide = "---------------------------------";

    internal static void RunMainMenu()
    {
        var productsController = new ProductsController();

        var isMenuRunning = true;

        while (isMenuRunning)
        {
            PrintHeader();

            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                 .Title("What would you like to do?")
            .AddChoices(
                MainMenuOptions.ViewProducts,
                MainMenuOptions.AddProduct,
                MainMenuOptions.DeleteProduct,
                MainMenuOptions.UpdateProduct,
                MainMenuOptions.QuitProgram)
                );

            var menuMessage = "Press Any Key To Go Back to Menu";

            switch (usersChoice)
            {
                case MainMenuOptions.AddProduct:
                    var product = GetProductInput();
                    productsController.AddProduct(product);
                    break;
                case MainMenuOptions.DeleteProduct:
                    productsController.DeleteProduct("User chose D");
                    break;
                case MainMenuOptions.ViewProducts:
                    var products = productsController.GetProducts();
                    ViewProducts(products);
                    break;
                case MainMenuOptions.UpdateProduct:
                    productsController.UpdateProduct("User chose U");
                    break;
                case MainMenuOptions.QuitProgram:
                    menuMessage = "Goodbye";
                    isMenuRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose one of the above");
                    break;
            }

            Console.WriteLine(menuMessage);
            Console.ReadLine();
            Console.Clear();
        }
    }

    internal static void ViewProducts(List<Product> products)
    {
        Console.WriteLine(divide);
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}");
        }
        Console.WriteLine(divide);
    }

    internal static void PrintHeader()
    {
        var title = "Mary's Candy Shop";
        var divide = "---------------------------------";
        var dateTime = DateTime.Now;
        var daysSinceOpening = Helpers.GetDaysSinceOpening();
        var todaysProfit = 5.5m;
        var targetAchieved = false;

        Console.WriteLine(@$"{title}
{divide}
Today's date: {dateTime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}$
Today's target achieved: {targetAchieved}
{divide}");
    }

    private static Product GetProductInput()
    {
        Console.WriteLine("Product name:");
        var name = Console.ReadLine();

        Console.WriteLine("Product price:");
        var price = decimal.Parse(Console.ReadLine());

        var type = AnsiConsole.Prompt(
               new SelectionPrompt<ProductType>()
                .Title("Product Type")
                .AddChoices(
                   ProductType.Lollipop,
                   ProductType.ChocolateBar)
                );

        if (type == ProductType.ChocolateBar)
        {
            Console.WriteLine("Cocoa %:");
            var cocoa = int.Parse(Console.ReadLine());

            return new ChocolateBar()
            {
                Name = name,
                Price = price,
                CocoaPercentage = cocoa
            };
        }

        Console.WriteLine("Shape:");
        var shape = Console.ReadLine();

        return new Lollipop
        {
            Name = name,
            Price = price,
            Shape = shape
        };
    }
}

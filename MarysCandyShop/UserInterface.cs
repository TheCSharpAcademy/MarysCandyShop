using Spectre.Console;
using static MarysCandyShop.Enums;
using static MarysCandyShop.Product;

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
                MainMenuOptions.ViewProductsList,
                MainMenuOptions.ViewSingleProduct,
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
                case MainMenuOptions.ViewProductsList:
                    var products = productsController.GetProducts();
                    ViewProducts(products);
                    break;
                case MainMenuOptions.ViewSingleProduct:
                    var productChoice = GetProductChoice();
                    ViewProduct(productChoice);
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

    private static void ViewProduct(Product productChoice)
    {
        var panel = new Panel(productChoice.GetProductForPanel());
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }

    private static Product GetProductChoice()
    {
        var productsController = new ProductsController();
        var products = productsController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productsArray));

        var product = products.Single(x => x.Name == option);

        return product;
    }

    internal static void ViewProducts(List<Product> products)
    {
        Console.WriteLine(divide);
        foreach (var product in products)
        {
            Console.WriteLine(product.GetProductForCsv(product.Id));
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
            .Title("Product Type:")
            .AddChoices(
                ProductType.Lollipop,
                ProductType.ChocolateBar)
            );

        if (type == ProductType.ChocolateBar)
        {
            Console.WriteLine("Cocoa %");
            var cocoa = int.Parse(Console.ReadLine());

            return new ChocolateBar()
            {
                Name = name,
                Price = price,
                CocoaPercentage = cocoa
            };
        }

        Console.WriteLine("Shape: ");
        var shape = Console.ReadLine();

        return new Lollipop
        {
            Name = name,
            Price = price,
            Shape = shape
        };
    }
}

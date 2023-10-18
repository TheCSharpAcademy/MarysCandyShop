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
                    var productToDelete = GetProductChoiceInput();
                    productsController.DeleteProduct(productToDelete);
                    break;
                case MainMenuOptions.ViewProductsList:
                    var products = productsController.GetProducts();
                    ViewProducts(products);
                    break;
                case MainMenuOptions.ViewSingleProduct:
                    var productToView = GetProductChoiceInput();
                    ViewProduct(productToView);
                    break;
                case MainMenuOptions.UpdateProduct:
                    var productToUpdate = GetProductChoiceInput();
                    var updatedProduct = GetProductUpdateInput(productToUpdate);
                    productsController.UpdateProduct(updatedProduct);
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
        foreach (var product in products.OrderBy(x => x.Id))
        {
            Console.WriteLine(product.GetProductForCsv());
        }
        Console.WriteLine(divide);
    }

    internal static void ViewProduct(Product product)
    {
        var panel = new Panel(product.GetProductForPanel());
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
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

    private static Product GetProductChoiceInput()
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

    private static Product GetProductUpdateInput(Product product)
    {
        Console.WriteLine("Choose Y/N to update each property. Or simply press Enter or Y.");

        product.Name = AnsiConsole.Confirm("Update name?") ? AnsiConsole.Ask<string>("Product's new name:") : product.Name;
        product.Price = AnsiConsole.Confirm("Update price?") ? AnsiConsole.Ask<decimal>("Product's new price:") : product.Price;

        var updateType = AnsiConsole.Confirm("Update category?");

        if (updateType)
        {
            var type = AnsiConsole.Prompt(
                new SelectionPrompt<ProductType>()
                .Title("Product Type:")
                .AddChoices(
                    ProductType.Lollipop,
                    ProductType.ChocolateBar));

            if (type == ProductType.ChocolateBar)
            {
                Console.WriteLine("Cocoa %");
                var cocoa = int.Parse(Console.ReadLine());

                return new ChocolateBar()
                {
                    Name = product.Name,
                    Price = product.Price,
                    CocoaPercentage = cocoa
                };
            }

            Console.WriteLine("Shape: ");
            var shape = Console.ReadLine();

            return new Lollipop()
            {
                Name = product.Name,
                Price = product.Price,
                Shape = shape
            };
        }

        return product;
    }
}

using Spectre.Console;
using static MarysCandyShop.Enums;
using static MarysCandyShop.Product;

namespace MarysCandyShop;

internal class UserInterface
{
    private readonly IProductsController _productsController;

    public UserInterface(IProductsController productsController)
    {
        _productsController = productsController;
    }

    internal void RunMainMenu()
    {
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
                    _productsController.AddProduct(product);
                    break;
                case MainMenuOptions.DeleteProduct:
                    var productToDelete = GetProductChoice();
                    _productsController.DeleteProduct(productToDelete);
                    break;
                case MainMenuOptions.ViewProductsList:
                    var products = _productsController.GetProducts();
                    ViewProducts(products);
                    break;
                case MainMenuOptions.ViewSingleProduct:
                    var productChoice = GetProductChoice();
                    ViewProduct(productChoice);
                    break;
                case MainMenuOptions.UpdateProduct:
                    var productToUpdate = GetProductChoice();
                    var updatedProduct = GetProductUpdateInput(productToUpdate);
                    _productsController.UpdateProduct(updatedProduct);
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

    private Product GetProductUpdateInput(Product product)
    {
        Console.WriteLine("You'll be prompted with the choice to update each property. Press enter for Yes and N for no.");

        product.Name = AnsiConsole.Confirm("Update name?") ? AnsiConsole.Ask<string>("Product's new name:") : product.Name;
        product.Price = AnsiConsole.Confirm("Update price?") ? AnsiConsole.Ask<decimal>("Product's new price:") : product.Price;

        var updateType = AnsiConsole.Confirm("Update category?");

        var type = ProductType.ChocolateBar;

        if (updateType)
        {
            type = AnsiConsole.Prompt(
                new SelectionPrompt<ProductType>()
                .Title("Product Type:")
                .AddChoices(
                    ProductType.ChocolateBar,
                    ProductType.Lollipop));
        }

        if (type == ProductType.ChocolateBar)
        {
            Console.WriteLine("Cocoa %");
            var cocoa = int.Parse(Console.ReadLine());

            return new ChocolateBar(product.Id)
            {
                Name = product.Name,
                Price = product.Price,
                CocoaPercentage = cocoa
            };
        }

        Console.WriteLine("Shape: ");
        var shape = Console.ReadLine();

        return new Lollipop(product.Id)
        {
            Name = product.Name,
            Price = product.Price,
            Shape = shape
        };

        return product;
    }

    private void ViewProduct(Product productChoice)
    {
        var panel = new Panel(productChoice.GetProductForPanel());
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }

    private Product GetProductChoice()
    {
        var products = _productsController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productsArray));

        var product = products.Single(x => x.Name == option);

        return product;
    }

    internal static void ViewProducts(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Type");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("CocoaPercentage");
        table.AddColumn("Shape");

        foreach (var product in products)
        {
            table.AddRow(product.GetColumnsArray(product));
        }

        AnsiConsole.Write(table);
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
        while (!Validation.IsStringValid(name))
        {
            Console.WriteLine("Name cannot be empty or have more than 20 characters. Try again:");
            name = Console.ReadLine();
        }

        Console.WriteLine("Product price:");
        var priceInput = Console.ReadLine();
        var priceValidation = Validation.IsPriceValid(priceInput);

        while (!priceValidation.IsValid)
        {
            Console.WriteLine(priceValidation.ErrorMessage);
            priceInput = Console.ReadLine();
            priceValidation = Validation.IsPriceValid(priceInput);
        }

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
            var cocoaInput = Console.ReadLine();
            var cocoaValidation = Validation.IsCocoaValid(cocoaInput);

            while (!cocoaValidation.IsValid)
            {
                Console.WriteLine(cocoaValidation.ErrorMessage);
                cocoaInput = Console.ReadLine();
                cocoaValidation = Validation.IsCocoaValid(cocoaInput);
            }

            return new ChocolateBar()
            {
                Name = name,
                Price = priceValidation.Price,
                CocoaPercentage = cocoaValidation.CocoaPercentage
            };
        }

        Console.WriteLine("Shape: ");
        var shape = Console.ReadLine();

        while (!Validation.IsStringValid(shape))
        {
            Console.WriteLine("Shape cannot be empty or have more than 20 characters. Try again:");
            shape = Console.ReadLine();
        }

        return new Lollipop
        {
            Name = name,
            Price = priceValidation.Price,
            Shape = shape
        };
    }
}

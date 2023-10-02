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

            var usersChoice = Console.ReadLine().Trim().ToUpper();
            var menuMessage = "Press Any Key To Go Back to Menu";

            switch (usersChoice)
            {
                case "A":
                    productsController.AddProduct();
                    break;
                case "D":
                    productsController.DeleteProduct("User chose D");
                    break;
                case "V":
                    var products = productsController.GetProducts();
                    ViewProducts(products);
                    break;
                case "U":
                    productsController.UpdateProduct("User chose U");
                    break;
                case "Q":
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

    internal static void ViewProducts(List<string> products)
    {
        Console.WriteLine(divide);
        foreach (var product in products)
        {
            Console.WriteLine(product);
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
        string menu = GetMenu();

        Console.WriteLine(@$"{title}
{divide}
Today's date: {dateTime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}$
Today's target achieved: {targetAchieved}
{divide}
{menu}");
    }

    private static string GetMenu()
    {
        return "Choose one option:\n"
            + 'V' + " to view products\n"
            + 'A' + " to add product\n"
            + 'D' + " to delete product\n"
            + 'U' + " to update product\n"
            + 'Q' + " to quit the program\n";
    }
}

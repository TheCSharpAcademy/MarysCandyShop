var isMenuRunning = true;
var products = new List<string>();

while (isMenuRunning)
{
    PrintHeader();
    RunMenu();
    Console.WriteLine("Press Any Key To Go Back to Menu");
    Console.ReadLine();
    Console.Clear();
};

void AddProduct()
{
    Console.WriteLine("Product Name:");
    var product = Console.ReadLine();
    products.Add(product);
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void UpdateProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProducts(string message)
{
    Console.WriteLine(message);
}

void PrintHeader()
{
    var title = "Mary's Candy Shop";
    var divide = "---------------------------------";
    var dateTime = DateTime.Now;
    var daysSinceOpening = 1;
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

string GetMenu()
{
    return "Choose one option:\n"
        + 'V' + " to view products\n"
        + 'A' + " to add product\n"
        + 'D' + " to delete product\n"
        + 'U' + " to update product\n"
        + 'Q' + " to quit program\n";
}

void RunMenu()
{
    var usersChoice = Console.ReadLine().Trim().ToUpper();

    switch (usersChoice)
    {
        case "A":
            AddProduct();
            break;
        case "D":
            DeleteProduct("User chose D");
            break;
        case "V":
            ViewProducts("User chose V");
            break;
        case "U":
            UpdateProduct("User chose U");
            break;
        case "Q":
            Console.WriteLine("Goodbye");
            isMenuRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please choose one of the above");
            break;
    }
}
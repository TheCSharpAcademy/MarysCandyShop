string[] candyNames = { "Rainbow Lollipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };
var products = new List<string>();
SeedData();

var divide = "---------------------------------";

var isMenuRunning = true;

while (isMenuRunning)
{
    PrintHeader();

    var usersChoice = Console.ReadLine().Trim().ToUpper();
    var menuMessage = "Press Any Key To Go Back to Menu";

    switch (usersChoice)
    {
        case "A":
            AddProduct();
            break;
        case "D":
            DeleteProduct("User chose D");
            break;
        case "V":
            ViewProducts();
            break;
        case "U":
            UpdateProduct("User chose U");
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

void SeedData()
{
    for (int i = 0; i < candyNames.Length; i++)
    {
        products.Add(candyNames[i]);
    }
}

void AddProduct()
{
    Console.WriteLine("Product name:");
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

void ViewProducts()
{
    Console.WriteLine(divide);
    foreach (var product in products)
    {
        Console.WriteLine($"{product}");
    }
    Console.WriteLine(divide);
}

void PrintHeader()
{
    var title = "Mary's Candy Shop";
    var divide = "---------------------------------";
    var dateTime = DateTime.Now;
    var daysSinceOpening = GetDaysSinceOpening();
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
        + 'Q' + " to quit the program\n";
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    var days = DateTime.Now - openingDate;

    return days.Days;
}
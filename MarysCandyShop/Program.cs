var isMenuRunning = true;
var products = new List<string>();
string[] candyNames = { "Rainbow Lollipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };

SeedData();

while (isMenuRunning)
{
    PrintHeader();
    RunMenu();
    Console.WriteLine("Press Any Key To Go Back to Menu");
    Console.ReadLine();
    Console.Clear();
};

void SeedData()
{
    for (int i = 0; i < 10; i++)
    {
        products.Add(candyNames[i]);
    }
    Console.WriteLine("Data was seeded!\n\n");
}

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

void ViewProducts()
{
    Console.WriteLine("\n------------");
    var productIndex = 1;
    foreach (var product in products)
    {
        Console.WriteLine($"{productIndex}: {product}");
        productIndex++;
    }
    Console.WriteLine("------------\n");
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
Product Count: {products.Count}
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
            ViewProducts();
            break;
        case "U":
            UpdateProduct("User chose U");
            break;
        case "Q":
            Console.WriteLine("Goodbye");
            SaveProducts();
            isMenuRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please choose one of the above");
            break;
    }
}

void SaveProducts()
{
    string docPath = @"C:\The.Csharp.School\MarysCandyShop\MarysCandyShop\history.txt";
    using (StreamWriter outputFile = new StreamWriter(docPath))
    {
        foreach (string product in products)
        {
            outputFile.WriteLine(product);
        }
    }
    Console.WriteLine("Products saved");
}
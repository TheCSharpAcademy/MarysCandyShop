PrintHeader();

var usersChoice = Console.ReadLine().Trim().ToUpper();

switch (usersChoice)
{
    case "A":
        AddProduct("User chose A");
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
    default:
        Console.WriteLine("Invalid choice. Please choose one of the above");
        break;
}

void AddProduct(string message)
{
    Console.WriteLine(message);
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
        + 'U' + " to update product\n";
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    var days = DateTime.Now - openingDate;

    return days.Days;
}
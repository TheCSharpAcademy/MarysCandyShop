 // Variables
var title = "Mary's Candy Shop";
var divide = "---------------------------------";
var dateTime = DateTime.Now;
var daysSinceOpening = 1;
var todaysProfit = 5.5m;
var targetAchieved = false;
var menu = "Choose one option:\n"
    + 'V' + " to view products\n"
    + 'A' + " to add product\n"
    + 'D' + " to delete product\n"
    + 'U' + " to update product\n";

Console.WriteLine(@$"{title}
{divide}
Today's date: {dateTime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}$
Today's target achieved: {targetAchieved}
{divide}
{menu}");

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




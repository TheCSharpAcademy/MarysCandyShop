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
        Console.WriteLine("User chose A");
        break;
    case "D":
        Console.WriteLine("User chose D");
        break;
    case "V":
        Console.WriteLine("User chose V");
        break;
    case "U":
        Console.WriteLine("User chose U");
        break;
    default:
        Console.WriteLine("Invalid choice. Please choose one of the above");
        break;
}



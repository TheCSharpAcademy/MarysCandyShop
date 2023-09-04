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

Console.WriteLine(title);
Console.WriteLine(divide);
Console.WriteLine("Today's date: " + dateTime);
Console.WriteLine("Days since opening: " + daysSinceOpening);
Console.WriteLine("Today's profit: " + todaysProfit + "$");
Console.WriteLine("Today's target achieved: " + targetAchieved);
Console.WriteLine(divide);
Console.WriteLine(menu);

var usersChoice = Console.ReadLine().Trim().ToUpper();

if (usersChoice == "A")
{
    Console.WriteLine("User chose A");
} 
else if (usersChoice == "D")
{
    Console.WriteLine("User chose D");
} 
else if (usersChoice == "V")
{
    Console.WriteLine("User chose V");
}
else if (usersChoice == "U")
{
    Console.WriteLine("User chose U");
}
else
{
    Console.WriteLine("Invalid choice. Please choose one of the above");
}



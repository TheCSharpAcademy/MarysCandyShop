namespace MarysCandyShop;

internal static class Helpers
{
    internal static int GetDaysSinceOpening()
    {
        var openingDate = new DateTime(2023, 1, 1);
        var days = DateTime.Now - openingDate;

        return days.Days;
    }
}

using MarysCandyShop.Models;

namespace MarysCandyShop;

internal static class Validation
{
    internal static bool IsStringValid(string? name)
    {
        return !string.IsNullOrEmpty(name) && name.Length <= 20;
    }

    internal static PriceValidationResponse IsPriceValid(string? priceInput)
    {
        var response = new PriceValidationResponse
        {
            IsValid = true,
        };

        decimal price;
        if (!decimal.TryParse(priceInput, out price))
        {
            response.IsValid = false;
            response.ErrorMessage = "Not a valid number";
        }

        if (price < 0 || price > 9999)
        {
            response.IsValid = false;
            response.ErrorMessage = "Price must be between 0 and 9999.";
        }

        response.Price = price;

        return response;
    }

    internal static CocoaValidationResponse IsCocoaValid(string? cocoaInput)
    {
        var response = new CocoaValidationResponse
        {
            IsValid = true,
        };

        int cocoaPercentage;
        if (!int.TryParse(cocoaInput, out cocoaPercentage))
        {
            response.IsValid = false;
            response.ErrorMessage = "Not a valid whole number";
        }

        if (cocoaPercentage < 0 || cocoaPercentage > 99)
        {
            response.IsValid = false;
            response.ErrorMessage = "Percentage must be between 0 and 99.";
        }

        response.CocoaPercentage = cocoaPercentage;

        return response;
    }

}

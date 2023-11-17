using System.ComponentModel.DataAnnotations;

namespace MarysCandyShop;

public class Enums
{
    public enum MainMenuOptions
    {
        ViewProductsList,
        ViewSingleProduct,
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        QuitProgram
    }

    public enum ProductType
    {
        [Display(Name = "Chocolate Bar")]
        ChocolateBar,

        [Display(Name = "Lollipop")]
        Lollipop
    }
}

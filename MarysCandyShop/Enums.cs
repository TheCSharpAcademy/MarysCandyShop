using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MarysCandyShop;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ViewProductsList,
        ViewSingleProduct,
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        QuitProgram
    }

    internal enum ProductType
    {
        [Display(Name = "Chocolate Bar")]
        ChocolateBar,

        [Display(Name = "Lollipop")]
        Lollipop
    }
}

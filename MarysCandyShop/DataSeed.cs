namespace MarysCandyShop;

internal class DataSeed
{
    string[] candyNames = { "Rainbow Lollipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };
    void SeedData()
    {
        var productsController = new ProductsController();

        productsController.AddProducts(candyNames.ToList());
    }
}

namespace MarysCandyShop;

internal class Product
{
    internal int Id { get; }
    internal string Name { get; set; }
    internal decimal Price { get; set; }    

    public Product (int id)
    {
        Id = id;
    }
}
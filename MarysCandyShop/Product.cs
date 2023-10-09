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

internal class ChocolateBar: Product
{
    internal string Flavor { get; set; }
    internal int CocoaPercentage { get; set; }
    internal bool IsOrganic { get; set; }

    public ChocolateBar(int id) : base(id)
    {
    }
}

internal class GummyCandy: Product
{
    internal string Shape { get; set; }
    internal int SugarContent { get; set; }
    internal string Color { get; set; }

    public GummyCandy(int id) : base(id)
    {
    }

}

internal class Lollipop: Product
{
    internal int Size { get; set; }
    internal string Flavor { get; set; }
    internal bool IsSour { get; set; }

    public Lollipop(int id) : base(id)
    {
    }
}
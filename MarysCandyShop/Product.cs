using static MarysCandyShop.Enums;

namespace MarysCandyShop;

internal abstract class Product
{
    internal int Id { get; }
    internal string Name { get; set; }
    internal decimal Price { get; set; }
    internal ProductType Type { get; set; }

    internal Product()
    {

    }

    internal Product(int id)
    {
        Id = id;
    }

    internal abstract string GetProductForCsv();

    internal abstract string GetProductForPanel();

    internal static Product CreateProductInstance(ProductType productType)
    {
        switch (productType)
        {
            case ProductType.ChocolateBar:
                return new ChocolateBar();
            case ProductType.Lollipop:
                return new Lollipop();
            default:
                throw new ArgumentException("Invalid product type");
        }
    }

    internal class ChocolateBar : Product
    {
        internal int CocoaPercentage { get; set; }

        internal ChocolateBar()
        {
            Type = ProductType.ChocolateBar;
        }

        internal ChocolateBar(int id) : base(id)
        {
            Type = ProductType.ChocolateBar;
        }

        internal override string GetProductForCsv()
        {
            return $"{Id},{(int)Type},{Name},{Price},{CocoaPercentage}";
        }

        internal override string GetProductForPanel()
        {
            return @$"Id: {Id},
Type: {(int)Type}
Name: {Name},
Price: {Price}
CocoaPercentage: {CocoaPercentage}";
        }
    }

    internal class Lollipop : Product
    {
        internal string Shape { get; set; }

        internal Lollipop()
        {
            Type = ProductType.Lollipop;
        }
        internal Lollipop(int id) : base(id)
        {
            Type = ProductType.Lollipop;
        }

        internal override string GetProductForCsv()
        {
            return $"{Id},{(int)Type},{Name},{Price},,{Shape}";
        }

        internal override string GetProductForPanel()
        {
            return @$"Id: {Id},
Type: {Type}
Name: {Name},
Price: {Price}
Shape: {Shape}";
        }
    }
}
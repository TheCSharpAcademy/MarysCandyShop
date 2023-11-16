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

    internal abstract string GetProductForCsv(int id);

    internal abstract string GetInsertQuery();

    internal abstract string GetProductForPanel();

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

        internal override string GetProductForCsv(int id)
        {
            return $"{id},{(int)Type},{Name},{Price},{CocoaPercentage}";
        }

        internal override string GetProductForPanel()
        {
            return $@"Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Cocoa Percentage: {CocoaPercentage}";
        }

        internal override string GetInsertQuery()
        {
            return $@"INSERT INTO products (name, price, type, cocoaPercentage) VALUES ('{Name}', {Price}, {(int)Type}, {CocoaPercentage})";
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

        internal override string GetProductForCsv(int id)
        {
            return $"{id},{(int)Type},{Name},{Price},,{Shape}";
        }

        internal override string GetProductForPanel()
        {
            return $@"Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Shape: {Shape}";
        }

        internal override string GetInsertQuery()
        {
            return $@"INSERT INTO products (name, price, type, shape) VALUES ('{Name}', {Price}, {(int)Type}, {Shape})";
        }
    }
}
using Microsoft.Data.Sqlite;
using Spectre.Console;
using static MarysCandyShop.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    internal abstract string[] GetColumnsArray(Product product);

    internal abstract string GetProductForPanel();

    internal abstract string GetInsertQuery();

    internal abstract string GetUpdateQuery();

    internal abstract void AddParameters(SqliteCommand cmd);

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

        internal override string[] GetColumnsArray(Product product)
        {
            return new string[] { 
                Id.ToString(), 
                Type.ToString(), 
                Name, Price.ToString(), 
                CocoaPercentage.ToString(), 
                "" }; 
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
            return $@"INSERT INTO products (name, price, type, cocoaPercentage) VALUES (@Name, @Price, @Type, @CocoaPercentage)";
        }

        internal override void AddParameters(SqliteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Type", (int)Type);
            cmd.Parameters.AddWithValue("@CocoaPercentage", CocoaPercentage);
        }

        internal override string GetUpdateQuery()
        {
            return $"UPDATE products SET name = @Name, price = @Price, type = 0, cocoapercentage = @CocoaPercentage WHERE Id = {Id}";
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

        internal override string[] GetColumnsArray(Product product)
        {
            return new string[] {
                Id.ToString(),
                Type.ToString(),
                Name, Price.ToString(),
                "",
                Shape.ToString()
            };
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
            return $@"INSERT INTO products (name, price, type, shape) VALUES (@Name, @Price, @Type, @Shape)";
        }

        internal override void AddParameters(SqliteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Type", (int)Type);
            cmd.Parameters.AddWithValue("@Shape", Shape);
        }

        internal override string GetUpdateQuery()
        {
            return $"" +
                $"UPDATE products SET name = @Name, price = @Price, type = 1, shape = @Shape WHERE Id = {Id}";
        }

    }
}
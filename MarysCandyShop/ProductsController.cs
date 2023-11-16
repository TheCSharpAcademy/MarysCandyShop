using Microsoft.Data.Sqlite;
using static MarysCandyShop.Enums;
using static MarysCandyShop.Product;

namespace MarysCandyShop;

internal class ProductsController
{
    private string ConnectionString { get; } = "Data Source = products.db";

    internal void CreateDatabase()
    {
        try
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = @"CREATE TABLE products (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Name TEXT NOT NULL,
	Price REAL NOT NULL,
	CocoaPercentage INTEGER NULL,
	Shape TEXT NULL,
	Type INTEGER NOT NULL
)";
            tableCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    internal List<Product> GetProducts()
    {
        var products = new List<Product>();

        try
        {
            using (StreamReader reader = new(Configuration.docPath))
            {
                reader.ReadLine(); //discard first line
                var line = reader.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');

                    if (int.Parse(parts[1]) == (int)ProductType.ChocolateBar)
                    {
                        var product = new ChocolateBar(int.Parse(parts[0]));
                        product.Name = parts[2];
                        product.Price = decimal.Parse(parts[3]);
                        product.CocoaPercentage = int.Parse(parts[4]);
                        products.Add(product);
                    }
                    else
                    {
                        var product = new Lollipop(int.Parse(parts[0]));
                        product.Name = parts[2];
                        product.Price = decimal.Parse(parts[3]);
                        product.Shape = parts[5];
                        products.Add(product);
                    }

                    line = reader.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(UserInterface.divide);
        }

        return products;
    }

    internal void AddProduct(Product product) 
    {
        try
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = product.GetInsertQuery();
            product.AddParameters(tableCmd);

            Console.WriteLine(tableCmd.CommandText);
            tableCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    internal void AddProducts(List<Product> products)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
            {
                outputFile.WriteLine("Id,Type,Name,Price,CocoaPercentage,Shape");

                foreach (var product in products)
                {
                    var csvLine = product.GetProductForCsv(product.Id);

                    outputFile.WriteLine(csvLine);
                }
            }
            Console.WriteLine("Products saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error saving products: " + ex.Message);
        }
    }

    internal void DeleteProduct(Product product)
    {
        var products = GetProducts();
        var updatedProducts = products.Where(p => p.Id != product.Id).ToList();

        AddProducts(updatedProducts);
    }

    internal void UpdateProduct(Product product)
    {
        var products = GetProducts();

        var updatedProducts = products.Where(p => p.Id != product.Id).ToList();
        updatedProducts.Add(product);

        AddProducts(updatedProducts);
    }
}

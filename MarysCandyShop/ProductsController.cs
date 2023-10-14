using System.Text;
using static MarysCandyShop.Enums;

namespace MarysCandyShop;

internal class ProductsController
{
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
        var id = GetProducts().Count;

        try
        {
            using (StreamWriter outputFile = new StreamWriter(Configuration.docPath, true, new UTF8Encoding(false)))
            {
                if( outputFile.BaseStream.Length <= 3)
                {
                    outputFile.WriteLine("Id,Type,Name,Price,CocoaPercentage,Shape");
                }

                var csvLine = $"{product.GetProductForCsv(id)}";
                outputFile.WriteLine(csvLine);
            }
            Console.WriteLine("Product saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error saving product: " + ex.Message);
        }
    }

    internal void AddProducts(List<Product> products)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
            {
                foreach(var product in products)
                {
                    outputFile.WriteLine($"{product.Id}, {product.Name}, {product.Price}");
                }
            }
            Console.WriteLine("Products saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error saving products: " + ex.Message);
        }
    }

    internal void DeleteProduct(string message)
    {
        Console.WriteLine(message);
    }

    internal void UpdateProduct(string message)
    {
        Console.WriteLine(message);
    }
}

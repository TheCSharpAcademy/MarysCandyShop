using System.Text;

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

                    var product = new Product(int.Parse(parts[0]));
                    product.Name = parts[1];
                    product.Price = decimal.Parse(parts[2]);

                    products.Add(product);

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

    internal void AddProduct()
    {
        var id = GetProducts().Count;

        Console.WriteLine("Product name:");
        var name = Console.ReadLine();

        Console.WriteLine("Product price:");
        var price = decimal.Parse(Console.ReadLine());
        try
        {
            using (StreamWriter outputFile = new StreamWriter(Configuration.docPath, true, new UTF8Encoding(false)))
            {
                if( outputFile.BaseStream.Length <= 3)
                {
                    outputFile.WriteLine("Id,Name,Price");
                }

                var csvLine = $"{id},{name},{price}";
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

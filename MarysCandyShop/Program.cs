using MarysCandyShop;

DataSeed.SeedData();

var productsController = new ProductsController();
productsController.CreateDatabase();

UserInterface.RunMainMenu();

Console.WriteLine();




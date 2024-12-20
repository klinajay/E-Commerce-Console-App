namespace E_Commerce_App
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Inventory inventory1 = new Inventory();

            Product product1 = new Product("Apple", 50.65, 80, "Kgs");
            inventory1.AddProductToInventory(product1);
            Product product2 = new Product("Strawberry", 5.65, 10, "nos");
            inventory1.AddProductToInventory(product2);
            Product product3 = new Product("Rice", 200, 40, "Kgs");
            inventory1.AddProductToInventory(product3);
            Product product4 = new Product("Wheat", 100, 50, "Kgs");
            inventory1.AddProductToInventory(product4);
            Product product5 = new Product("Cashew", 12, 700, "Kgs");

            inventory1.DisplayAllAvailableProducts();
        }
    }
}
namespace E_Commerce_App
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Inventory inventory1 = new Inventory();
            CustomerList customerList = new CustomerList();

            //Demo product addition to inventory.
            Product product1 = new Product("Apple", 50.65, 80, "Kgs");
            inventory1.AddProductToInventory(product1);
            Product product2 = new Product("Strawberry", 5.65, 10, "nos");
            inventory1.AddProductToInventory(product2);
            Product product3 = new Product("Rice", 200, 40, "Kgs");
            inventory1.AddProductToInventory(product3);
            Product product4 = new Product("Wheat", 100, 50, "Kgs");
            inventory1.AddProductToInventory(product4);
            Product product5 = new Product("Cashew", 12, 700, "Kgs");

            //Demo customers addition
            Customer customer1 = new Customer(
                name: "Rohan Sharma",
                email: "rohan.sharma@example.com",
                phone: "9876543210",
                password: "password123",
                type: "Customer",
                age: 28,
                userName: "rohan_s"
            );

            Customer customer2 = new Customer(
                name: "Anjali Verma",
                email: "anjali.verma@example.com",
                phone: "9123456789",
                password: "securepass",
                type: "Customer",
                age: 25,
                userName: "anjali_v"
            );

            Customer customer3 = new Customer(
                name: "Amitabh Singh",
                email: "amitabh.singh@example.com",
                phone: "9345678901",
                password: "pass@123",
                type: "Customer",
                age: 32,
                userName: "amitabh_s"
            );

            //checking AddCustomer working
            customerList.AddCustomer(customer1 );
            customerList.AddCustomer(customer2);
            customerList.AddCustomer(customer3);

            //checking AddToCart and ViewCart working
            customer1.AddToCart(product1, 1, inventory1);
            customer1.AddToCart(product2, 1, inventory1);
            customer1.ViewCart();

            //checking inventory workings.
            //inventory1.DisplayAllAvailableProducts();
            inventory1.SearchProductInInventory("rce");

            //orders working checking
            OnlineOrder order1 = new OnlineOrder(customer1 , false , "rehansharma123" );
            
            
        }
    }
}
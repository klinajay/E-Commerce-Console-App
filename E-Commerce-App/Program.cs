using System;
using System.Transactions;

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
            //customer1.ViewCart();

            //checking inventory workings.
            //inventory1.DisplayAllAvailableProducts();
            inventory1.SearchProductInInventory("rce");

            //orders working checking
            OnlineOrder order1 = new OnlineOrder(customer1 , false , "rehansharma123" );


            Console.WriteLine("***** Welcome to E-Commerce-Console App. *****");
            Console.WriteLine("***** Who are you? *****");
            Console.WriteLine("Press the corresponding action number t0 perform particular action.");
            Console.WriteLine("1: Customer  2: Vendor");
            int.TryParse(Console.ReadLine() , out int type);
            if (type != 1 && type != 2)
            {
                Console.WriteLine("Please enter the valid option either 1 or 2.");
            }    
            
            if(type == 1)

            {
                Console.WriteLine("1 : Existing   2: New Customer");
                int.TryParse(Console.ReadLine(), out int internalType);
                if (internalType != 1 && internalType != 2)
                {
                    Console.WriteLine("Please enter the valid option either 1 or 2.");
                }
                if(internalType == 2)
                {
                    string personName;
                    string email;
                    string phoneNumber;
                    int age;
                    string typeCustormerOrVendor;
                    string password;
                    string userName;
                    Console.WriteLine("Enter the below details to create new account.");
                    Console.Write($"Enter your name: ");
                    personName = Console.ReadLine();
                    Console.Write($"Enter your email: ");
                     email = Console.ReadLine();
                    Console.Write($"Enter your phone number: ");
                    phoneNumber = Console.ReadLine();
                    Console.Write($"Enter your age: ");
                    int.TryParse(Console.ReadLine(), out age);
                    Console.Write($"Enter your unique username: ");
                    userName = Console.ReadLine();
                    Console.Write($"Enter your password: ");
                    password = Console.ReadLine();
                    int action = 101;
                    Console.WriteLine();

                    Customer customer = new Customer(personName, email, phoneNumber, password, "Customer", age, userName);
                    customerList.AddCustomer(customer);
                    Console.WriteLine();

                    do
                    {
                        
                        if (action < 0 && action >= 6 && action != 100)
                        {
                            Console.WriteLine("Please enter the valid option for actions");
                        }
                        Console.WriteLine("Press the corresponding action number t0 perform particular action.");
                        Console.WriteLine();
                        Console.WriteLine("1 : View inventory");
                        Console.WriteLine("2 : Add product to cart");
                        Console.WriteLine("3 : Remove product from cart");
                        Console.WriteLine("4 : View cart");
                        Console.WriteLine("5: View profile information");
                        Console.WriteLine("100 : exit");
                        int.TryParse(Console.ReadLine(), out action);

                        switch (action)
                        {
                            case 1:
                                {
                                    inventory1.DisplayAllAvailableProducts();
                                }
                                break;
                            case 2:
                                {
                                    Console.Write("Enter the Name of the product: ");
                                    string productName = Console.ReadLine();
                                    Console.Write("Enter the quantity of the product: ");
                                    double.TryParse(Console.ReadLine(), out double quantity);
                                    Product product = inventory1.SearchProductInInventory(productName);
                                    customer.AddToCart(product, quantity, inventory1);
                                }
                                break;
                            case 3:
                                {
                                    if(customer.GetCart().Count == 0)
                                    {
                                        Console.WriteLine("Nothing is there in your cart.");
                                    }
                                    else
                                    {
                                        Console.Write("Enter the product to remove.: ");
                                        string productName = Console.ReadLine();
                                        customer.DeleteProductFromCart(productName);
                                    }
                                    
                                }
                                break;
                            case 4:
                                {
                                    customer.ViewCart();
                                }
                                break;
                            case 5:
                                {
                                    customer.ShowProfile();
                                }
                                break;
                        }
                        Console.WriteLine();
                    }
                    while (action != 100);

                   
                }
                else if(internalType == 1)
                {
                    Console.Write("Enter your username.");
                    string username = Console.ReadLine();
                    Console.Write("Enter your password.");
                    string password = Console.ReadLine();
                    Customer customer = null;
                    int action = 101;
                    if (!customerList.customerList.ContainsKey(username))
                    {
                        Console.WriteLine("User not found, please create account first.");
                        return;
                        
                    }
                    else
                    {
                        foreach(var item in customerList.customerList)
                        {
                            if(item.Key == username)
                            {
                                customer = item.Value;
                                break;
                            }
                        }
                    }
                    customer.Login(password, username , customer);
                    
                    do
                    {
                        
                        Console.WriteLine();

                        if (action < 0 && action >= 6 && action != 100)
                        {
                            Console.WriteLine("Please enter the valid option for actions");
                        }
                        Console.WriteLine("Press the corresponding action number t0 perform particular action.");
                        Console.WriteLine();
                        Console.WriteLine("1 : View inventory");
                        Console.WriteLine("2 : Add product to cart");
                        Console.WriteLine("3 : Remove product from cart");
                        Console.WriteLine("4 : View cart");
                        Console.WriteLine("5: View profile information");
                        Console.WriteLine("100 : exit");
                        int.TryParse(Console.ReadLine(), out action);

                        switch (action)
                        {
                            case 1:
                                {
                                    inventory1.DisplayAllAvailableProducts();
                                }
                                break;
                            case 2:
                                {
                                    Console.Write("Enter the Name of the product: ");
                                    string productName = Console.ReadLine();
                                    Console.Write("Enter the quantity of the product: ");
                                    double.TryParse(Console.ReadLine(), out double quantity);
                                    Product product = inventory1.SearchProductInInventory(productName);
                                    if(customer != null)
                                    {
                                        customer.AddToCart(product, quantity, inventory1);
                                    }
                                }
                                break;
                            case 3:
                                {
                                    Console.Write("Enter the product to remove.: ");
                                    string productName = Console.ReadLine();
                                    customer.DeleteProductFromCart(productName);
                                }
                                break;
                            case 4:
                                {
                                    customer.ViewCart();
                                }
                                break;
                            case 5:
                                {
                                    customer.ShowProfile();
                                }
                                break;
                        }
                        Console.WriteLine();
                    }
                    while (action != 100);
                }

            }
            
        }
    }
}
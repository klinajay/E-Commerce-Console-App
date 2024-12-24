using System;

namespace E_Commerce_App
{
    internal class Program
    {
        private static Inventory inventory = new Inventory();
        private static CustomerList customerList = new CustomerList();
        private static VendorList vendorList = new VendorList();

        private static void Main(string[] args)
        {
            InitializeData();

            Console.WriteLine("***** Welcome to E-Commerce-Console App. *****");
            Console.WriteLine("***** Who are you? *****");
            Console.WriteLine("1: Customer  2: Vendor");

            if (!int.TryParse(Console.ReadLine(), out int userType) || (userType != 1 && userType != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 for Customer or 2 for Vendor.");
                return;
            }

            if (userType == 1)
            {
                HandleCustomerActions();
            }
            else
            {
                Console.WriteLine("Vendor functionality is not implemented yet.");
            }
        }

        private static void InitializeData()
        {
            
            inventory.AddProductToInventory(new Product("Apple", 50.65, 80, "Kgs"));
            inventory.AddProductToInventory(new Product("Strawberry", 5.65, 10, "nos"));
            inventory.AddProductToInventory(new Product("Rice", 200, 40, "Kgs"));
            inventory.AddProductToInventory(new Product("Wheat", 100, 50, "Kgs"));

            
            customerList.AddCustomer(new Customer("Rohan Sharma", "rohan.sharma@example.com", "9876543210", "password123", "Customer", 28, "rohan_s"));
            customerList.AddCustomer(new Customer("Anjali Verma", "anjali.verma@example.com", "9123456789", "securepass", "Customer", 25, "anjali_v"));
            customerList.AddCustomer(new Customer("Amitabh Singh", "amitabh.singh@example.com", "9345678901", "pass@123", "Customer", 32, "amitabh_s"));
        }

        private static void HandleCustomerActions()
        {
            Console.WriteLine("1: Existing Customer   2: New Customer");

            if (!int.TryParse(Console.ReadLine(), out int customerType) || (customerType != 1 && customerType != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 for Existing or 2 for New Customer.");
                return;
            }

            if (customerType == 1)
            {
                HandleExistingCustomer();
            }
            else if (customerType == 2)
            {
                HandleNewCustomer();
            }
        }

        private static void HandleNewCustomer()
        {
            Console.WriteLine("Enter the following details to create a new account:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Age: ");
            int.TryParse(Console.ReadLine(), out int age);
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Customer newCustomer = new Customer(name, email, phoneNumber, password, "Customer", age, username);
            customerList.AddCustomer(newCustomer);
            Console.WriteLine("Account created successfully.");

            CustomerMenu(newCustomer);
        }

        private static void HandleExistingCustomer()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (!customerList.customerList.TryGetValue(username, out Customer existingCustomer))
            {
                Console.WriteLine("User not found. Please create an account first.");
                return;
            }
            else
            {
                existingCustomer.Login(password, username, existingCustomer);
            }
            CustomerMenu(existingCustomer);

        }

        private static void CustomerMenu(Customer customer)
        {
            int action;
            do
            {
                Console.WriteLine("\nPress the corresponding action number to perform a task:");
                Console.WriteLine("1: View Inventory");
                Console.WriteLine("2: Add Product to Cart");
                Console.WriteLine("3: Remove Product from Cart");
                Console.WriteLine("4: View Cart");
                Console.WriteLine("5: Place online order");
                Console.WriteLine("6: Place offline order");
                Console.WriteLine("7: View Profile");
                Console.WriteLine("100: Exit");

                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (action)
                {
                    case 1:
                        inventory.DisplayAllAvailableProducts();
                        break;
                    case 2:
                        AddProductToCartHelper(customer);
                        break;
                    case 3:
                        RemoveProductFromCartHelper(customer);
                        break;
                    case 4:
                        customer.ViewCart();
                        break;
                    case 5:
                        OnlineOrderHelper(customer);
                        break;
                    case 6:
                        PhysicalOrderHelper(customer);
                        break;
                    case 7:
                        customer.ShowProfile();
                        break;
                    case 100:
                        Console.WriteLine("Exiting customer menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (action != 100);
        }

        private static void AddProductToCartHelper(Customer customer)
        {
            Console.Write("Enter the Name of the product: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the quantity of the product: ");
            double.TryParse(Console.ReadLine(), out double quantity);

            Product product = inventory.SearchProductInInventory(productName);
            if (product != null)
            {
                customer.AddToCart(product, quantity, inventory);
            }
            else
            {
                Console.WriteLine("Product not found in inventory.");
            }
        }
        private static void OnlineOrderHelper(Customer customer)
        {
            Console.Write("Enter your paymentId: ");
            string paymentId = Console.ReadLine();
            OnlineOrder order = new OnlineOrder(customer, false, paymentId);
            order.ProceedOrder(customerList.customerList,customer.GetCustomerId(),inventory.inventoryList);
        }
        private static void PhysicalOrderHelper(Customer customer)
        {

        }
        private static void RemoveProductFromCartHelper(Customer customer)
        {
            Console.Write("Enter the Name of the product to remove: ");
            string productName = Console.ReadLine();

            customer.DeleteProductFromCart(productName, inventory);
        }
    }
}

using System;

namespace E_Commerce_App
{
    internal class Program
    {
        public static Inventory inventory = new Inventory();
        public static CustomerList customerList = new CustomerList();
        public static VendorList vendorList = new VendorList();
        public static SortedList<Vendor, VendorOrders> RequestList = new SortedList<Vendor, VendorOrders>();
        private static Admin admin = new Admin("Riya Chauhan","riyachauhan@gmail.com","8787654532","123456","Admin",25,"admin");
        private static void Main(string[] args)
        {
            InitializeData();

            Console.WriteLine("***** Welcome to E-Commerce-Console App. *****");
            Console.WriteLine("***** Who are you? *****");
            Console.WriteLine("1: Customer  2: Vendor 3: Admin 100: Exit");
            if (!int.TryParse(Console.ReadLine(), out int userType) || (userType < 1 && userType > 3))
            {
               
                Console.WriteLine("Invalid input. Please enter valid number.");
                return;
            }

            while (userType != 100)
            {
                if (userType == 1)
                {
                    HandleCustomerActions();
                }
                else if (userType == 2)
                {
                    HandleVendorActions();
                }
                else if(userType == 3)
                {
                    HandleAdminActions();
                }
                Console.WriteLine("***** Who are you? *****");
                Console.WriteLine("1: Customer  2: Vendor 3: Admin 100: Exit");
                if (!int.TryParse(Console.ReadLine(), out  userType) || (userType < 1 && userType > 3))
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Customer or 2 for Vendor.");
                    return;
                }
            }

            

        }

        private static void InitializeData()
        {
            
            inventory.AddProductToInventory(new Product("Apple", 50.65, 80, "Kgs"));
            inventory.AddProductToInventory(new Product("Strawberry", 5.65, 10, "nos"));
            inventory.AddProductToInventory(new Product("Rice", 200, 40, "Kgs"));
            inventory.AddProductToInventory(new Product("Wheat", 100, 50, "Kgs"));
            inventory.AddProductToInventory(new Product("Makhana", 0, 50, "Kgs"));


            customerList.AddCustomer(new Customer("Rohan Sharma", "rohan.sharma@example.com", "9876543210", "1234", "Customer", 28, "rohan_s"));
            customerList.AddCustomer(new Customer("Anjali Verma", "anjali.verma@example.com", "9123456789", "securepass", "Customer", 25, "anjali_v"));
            customerList.AddCustomer(new Customer("Amitabh Singh", "amitabh.singh@example.com", "9345678901", "pass@123", "Customer", 32, "amitabh_s"));
            vendorList.AddVendorsToList(new Vendor(
            "Rahul Mehta",
            "rahul.mehta@example.com",
            "9123456789",
            "rahul123",
            "Vendor",
            35,
            "rahul_m"
            ));

            vendorList.AddVendorsToList(new Vendor(
                "Priya Kapoor",
                "priya.kapoor@example.com",
                "9876543211",
                "secure@priya",
                "Vendor",
                30,
                "priya_k"
            ));

            vendorList.AddVendorsToList(new Vendor(
                "Anil Kumar",
                "anil.kumar@example.com",
                "9321567890",
                "anil@password",
                "Vendor",
                40,
                "anil_k"
            ));

            //Vendor vendor1 = vendorList.vendorList["rahul_m"];
            //VendorOrders order1 = new VendorOrders(vendor1, false);
            //vendor1.GetCart().Add("Aple", new Product("Apple", 50.65, 80, "Kgs"));
            //order1.ProceedOrder(vendor1.GetVendorId(true));
            //Console.WriteLine("CAlling inventoruy");
            //inventory.DisplayAllAvailableProducts();
            
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
        private static void HandleVendorActions()
        {

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (!vendorList.vendorList.TryGetValue(username, out Vendor existingVendor))
            {
                Console.WriteLine("User not found. Please create an account first.");
                return;
            }
            else
            {
                existingVendor.Login(password, username);
                VendorMenu(existingVendor);

            }

        }
        private static void HandleAdminActions()
        {

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (!(admin.GetAdminId(true) == username))
            {
                Console.WriteLine("User not found. Please create an account first.");
                return;
            }
            else
            {
                admin.Login(password, username);
                AdminMenu();

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
                existingCustomer.Login(password, username);
                CustomerMenu(existingCustomer);

            }


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
        private static void VendorMenu(Vendor vendor)
        {
            int action;
            do
            {
                Console.WriteLine("\nPress the corresponding action number to perform a task:");   
                Console.WriteLine("1: Add Product to Request List of admin");
                Console.WriteLine("2: Order status");   
                Console.WriteLine("3: View Profile");
                Console.WriteLine("100: Exit");

                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (action)
                {
                    case 1:
                        AddToRequestListHelper(vendor);
                        break;
                    case 2:
                        Console.WriteLine("Functionality yet to be implemented");
                        break;
                    case 3:
                        vendor.ShowProfile();
                        break;
                    case 100:
                        Console.WriteLine("Exiting Vendors menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (action != 100);
        }
        private static void AdminMenu()
        {
            int action;
            do
            {
                Console.WriteLine("\nPress the corresponding action number to perform a task:");
                Console.WriteLine("1: Approve products from the request list");
                Console.WriteLine("2: View inventory");
                Console.WriteLine("3: Cleanup of inventory");
                Console.WriteLine("4: View profile");
                Console.WriteLine("100: Exit");

                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (action)
                {
                    case 1:
                        admin.ApproveOrders(RequestList);
                        break;
                    case 2:
                        inventory.DisplayAllAvailableProducts();
                        break;
                    case 3:
                        admin.CleanupInventory(inventory);
                        break;
                    case 4:
                        admin.ShowProfile();
                        break;
                    case 100:
                        Console.WriteLine("Exiting Admin menu.");
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
        private static void AddToRequestListHelper(Vendor vendor)
        {
            Console.Write("Enter the Name of the product: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the quantity of the product: ");
            double.TryParse(Console.ReadLine(), out double quantity);
            Console.WriteLine("Enter the price of the product: ");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine("Enter the quantity Type 1: Kgs 2: nos");
            int.TryParse(Console.ReadLine(), out int quantityType);
            string type = quantityType == 1 ? "Kgs" : "nos";

            //Product product = new Product(productName, price, quantity, type);
            Product product = inventory.SearchProductInInventory(productName);
            if (product != null)
            {               
                vendor.AddProductToRequestList(product, RequestList);
                foreach (var item in RequestList)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine(item.Value);
                }
            }
            else
            {
                Product product1 = new Product(productName, price, quantity, type);
                vendor.AddProductToRequestList(product1, RequestList);
                Console.WriteLine("Product not found in inventory.");
            }
        }
        private static void OnlineOrderHelper(Customer customer)
        {
            Console.Write("Enter your paymentId: ");
            string paymentId = Console.ReadLine();
            OnlineOrder order = new OnlineOrder(customer, false, paymentId);
            order.ProceedOrder(customer.GetCustomerId());
        }
        private static void PhysicalOrderHelper(Customer customer)
        {
            PhysicalOrder order = new PhysicalOrder(customer, false);
            order.ProceedOrder(customer.GetCustomerId());
        }
        private static void RemoveProductFromCartHelper(Customer customer)
        {
            Console.Write("Enter the Name of the product to remove: ");
            string productName = Console.ReadLine();

            customer.DeleteProductFromCart(productName, inventory);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class Customer : AbstractClassPerson
    {
        private SortedList<string, double> cart;
        private string customerId;
        //private SortedList<string, Product> Orders;

        public Customer(String name, string email, string phone, string password, string type, int age, string userName)
        {
            personName = name;
            cart = new SortedList<string, double>();
            SetEmail(email, true);
            SetPhoneNumber(phone, true);
            SetAge(age, true);
            SetPassword(password, true);
            SetTypeCustomerOrVendor(type, true);
            SetUsername(userName, true);
        }

        public void ShowProfile()
        {
            
            Console.WriteLine($"name: {this.personName}");
            Console.WriteLine($"email: {this.email}");
            Console.WriteLine($"phone number: {this.phoneNumber}");
            Console.WriteLine($"username: {this.customerId}");
            Console.WriteLine($"password: {this.password}");
        }
        public SortedList<string, double> GetCart()
        {
            return cart;
        }
        public override string GetEmail(bool isAuthorized)
        {
            return isAuthorized ? email : "Authorization requi red!";
        }

        public override string GetPhoneNumber(bool isAuthorized)
        {
            return isAuthorized ? phoneNumber : "Authorization required!";
        }

        public override int GetAge(bool isAuthorized)
        {
            return isAuthorized ? age : -1; // Returning -1 to indicate lack of authorization
        }

        public override string GetTypeCustomerOrVendor(bool isAuthorized)
        {
            return isAuthorized ? typeCustormerOrVendor : "Authorization required!";
        }

        public string GetCustomerId()
        {
            return customerId;
        }

        public override void SetEmail(string newEmail, bool isAuthorized)
        {
            if (isAuthorized)
            {
                email = newEmail;

            }
            else
            {
                Console.WriteLine("Authorization required to update email.");
            }
        }

        public override void SetPhoneNumber(string newPhoneNumber, bool isAuthorized)
        {
            if (isAuthorized)
            {
                phoneNumber = newPhoneNumber;

            }
            else
            {
                Console.WriteLine("Authorization required to update phone number.");
            }
        }

        public override void SetAge(int newAge, bool isAuthorized)
        {
            if (isAuthorized)
            {
                age = newAge;

            }
            else
            {
                Console.WriteLine("Authorization required to update age.");
            }
        }

        public override void SetTypeCustomerOrVendor(string newType, bool isAuthorized)
        {
            if (isAuthorized)
            {
                typeCustormerOrVendor = newType;

            }
            else
            {
                Console.WriteLine("Authorization required to update type.");
            }
        }
        public override void SetPassword(string newPassword, bool isAuthorized)
        {
            if (isAuthorized)
            {
                password = newPassword;

            }
            else
            {
                Console.WriteLine("Authorization required to update password.");
            }
        }
        public void SetUsername(string userName, bool isAuthorized)
        {

            if (isAuthorized)
            {
                customerId = userName;

            }
            else
            {
                Console.WriteLine("Authorization required to update password.");
            }
        }
        public void AddToCart(Product product, double quantity, Inventory inventory)
        {

            if (inventory.inventoryList.ContainsKey(product.productName))
            {
                if (inventory.inventoryList[product.productName].availableQuantity >= quantity)
                {
                    cart.Add(product.productName, quantity);
                    Console.WriteLine("Product added successfuly");
                }
                else
                {
                    Console.WriteLine($"Only {product.availableQuantity} {product.quantityType} {product.productName} is available.");
                }

            }
            else
            {
                Console.WriteLine("Enter valid product name.");
            }


            
        }
        public void ViewCart()
        {
            if(cart.Count == 0)
            {
                Console.WriteLine("Nothing is there in your cart.");
                return;
            }
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        public void DeleteProductFromCart(string productName)
        {
            if (this.cart.ContainsKey(productName))
            {
                cart.Remove(productName);
                Console.WriteLine($"{productName} removed from cart");
            }
            else
            {
                Console.WriteLine($"{productName} is not present in cart.");
            }
        }

        //implement removal on index.
    }
}

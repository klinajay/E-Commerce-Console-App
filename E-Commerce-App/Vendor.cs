using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class Vendor : Person
    {
        private SortedList<string, Product> cart;
        private string vendorId;
        

        public Vendor(String name, string email, string phone, string password, string type, int age, string userName)
        {
            personName = name;
            cart = new SortedList<string, Product>();
            SetEmail(email, true);
            SetPhoneNumber(phone, true);
            SetAge(age, true);
            SetPassword(password, true);
            SetTypeCustomerOrVendor(type, true);
            vendorId = userName;
        }
        public SortedList<string, Product> GetCart()
        {
            return cart;
        }
        public void SetCart(SortedList<string, Product> cart)
        {
            this.cart = cart;
        }
        public override string GetEmail(bool isAuthorized)
        {
            return isAuthorized ? email : "Authorization required!";
        }
        public string GetVendorId(bool isAuthorized)
        {
            return vendorId;
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
        public void AddToCart(Product product, Inventory inventory)
        {

           cart.Add(product.productName, product);
            Console.WriteLine("Product added to cart successfully.");

        }
        //public void SupplyProductToInventory(Product)
        //{

        //}
    }
}

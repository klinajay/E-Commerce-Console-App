using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using E_Commerce_App.Services;

namespace E_Commerce_App.Models
{
    internal class Customer : Person
    {
        private SortedList<string, double> cart;
        public string CustomerId { get; set; }
        //private SortedList<string, Product> Orders;

        public Customer(string name, string email, string phone, string password, string type, int age, string userName)
        {
            PersonName = name;
            cart = new SortedList<string, double>();
            Email = email;
            PhoneNumber = phone;
            Age = age;
            Password = password;
            RoleType = type;
            CustomerId = userName;
            InventoryManagementService reduceQuantityService = new InventoryManagementService();
            ProductAdded += reduceQuantityService.OnProductAddedToCart;
        }

        public void ShowProfile()
        {

            Console.WriteLine($"name: {PersonName}");
            Console.WriteLine($"email: {Email}");
            Console.WriteLine($"phone number: {PhoneNumber}");
            Console.WriteLine($"username: {CustomerId}");
            Console.WriteLine($"password: {Password}");
        }
        public delegate void AddedProductEventHandler(object source, ProductEventArgs args);
        public event AddedProductEventHandler ProductAdded;
        protected virtual void OnProductAddedToCart(object source, ProductEventArgs args)
        {
            if (ProductAdded != null)
            {
                ProductAdded(this, args);
            }
        }
        public SortedList<string, double> GetCart()
        {
            return cart;
        }
       
        public void AddToCart(Product product, double quantity, Inventory inventory)
        {


            if (inventory.inventoryList.ContainsKey(product.productName))
            {
                if (inventory.inventoryList[product.productName].availableQuantity >= quantity)
                {
                    bool flag = false;
                    if (cart.ContainsKey(product.productName))
                    {
                        cart[product.productName] += quantity;
                        OnProductAddedToCart(this, new ProductEventArgs(product.productName, quantity, ref inventory));
                        flag = true;
                    }
                    else
                    {
                        cart.Add(product.productName, quantity);
                        OnProductAddedToCart(this, new ProductEventArgs(product.productName, quantity, ref inventory));
                        flag = true;
                    }

                    if (flag)
                    {
                        Console.WriteLine("Product added to cart successfuly");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. pleage try again.");
                    }

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
            if (cart.Count == 0)
            {
                Console.WriteLine("Nothing is there in your cart.");
                return;
            }
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }

        public void DeleteProductFromCart(string productName, Inventory inventory)
            
        {
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Product name cannot be null or empty.");
                return;
            }
            if (cart.ContainsKey(productName))
            {
                bool flag = false;
                double quantity = cart[productName];
                cart.Remove(productName);
                flag = inventory.IncreaseQuantityOfProductFromInventory(productName, quantity);
                if (flag)
                {
                    Console.WriteLine($"{productName} removed from cart successfuly");
                }
                else
                {
                    Console.WriteLine("Something went wrong. pleage try again.");
                }
            }
            else
            {
                Console.WriteLine($"{productName} is not present in cart.");
            }
        }

        //implement removal on index.
    }
}

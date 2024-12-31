using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_App.Data;

namespace E_Commerce_App.Models
{
    internal class Admin : Person
    {

        public string AdminId { get; set; }


        public Admin(string name, string email, string phone, string password, string type, int age, string userName)
        {
            PersonName = name;
            Email = email;
            PhoneNumber = phone;
            Age = age;
            Password = password;
            RoleType = type;
        }


       
      
        public void ApproveOrders(SortedList<Vendor, VendorOrders> requestList)
        {
            if (requestList == null)
            {
                Console.WriteLine("Null request list is not accepted.");
                return;
            }
            else if (requestList.Count == 0)
            {
                Console.WriteLine("No orders to approve.");
            }
            else
            {
                foreach (var entry in requestList)
                {
                    Console.WriteLine("Order approved for vendor: " + entry.Key.VendorId);
                    entry.Value.ProceedOrder(entry.Key.VendorId);
                }
            }
        }
       
       
        public void CleanupInventory(Inventory inventory)
        {
            Console.WriteLine("Cleaning up the inventory...");
            Thread.Sleep(2000);
            if (inventory.inventoryList.Count <= 0)
            {
                Console.WriteLine("Inventory is already empty.");
            }
            else
            {
                List<Product> list;
                list = (from product in inventory.inventoryList where product.Value.availableQuantity <= 0 select product.Value).ToList();
                foreach (var item in list)
                {

                    inventory.inventoryList.Remove(item.productName);
                }
            }
        }

    }
}

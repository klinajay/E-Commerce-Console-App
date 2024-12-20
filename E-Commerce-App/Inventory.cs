using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class Inventory
    {
        public SortedList<string, Product> inventoryList;

        public Inventory()
        {
            inventoryList = new SortedList< string , Product>();
        }
        public void DisplayAllAvailableProducts()
        {
            foreach (KeyValuePair<string , Product> pair in this.inventoryList)

            {
                Console.WriteLine($"{pair.Value.productName}        {pair.Value.availableQuantity}        {pair.Value.quantityType}        {pair.Value.ProductPrice}");
            }
        }

        public void IncreaseQuantityOfExhistingProduct(Product product)
        {
            this.inventoryList.Add(product.productName, product);
            
        }

        //returns 1 if product already exhists , returns 2 if new product added. 
        public int AddProductToInventory(Product product)
        {
            if (this.inventoryList.ContainsKey(product.productName))
            {
                IncreaseQuantityOfExhistingProduct(product);
                return 1;
            }
            else
            {
                this.inventoryList.Add(product.productName, product);
                return 2;
            }
        }

        public bool RemoveProductFromInventory(string productName)
        {
            if (this.inventoryList.ContainsKey(productName))
            {
                this.inventoryList.Remove(productName);
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public Product SearchProductInInventory(string productName)
        {
            if (this.inventoryList.ContainsKey(productName))
            {
                Console.WriteLine("Product Found");
                Product product = this.inventoryList[productName];
                return product;
            }
            else
            {
                Console.WriteLine("Product Not Found");
                return null;
            }

        }
        //public bool ReduceQuantityOfProductFromInventory(string productName)
        //{
        //    if (this.inventoryList.ContainsKey(productName))
        //    {
        //        Product product = SearchProductInInventory(productName);
        //        if (product != null)
        //        {
        //            if (this.inventoryList.Remove(productName))
        //            {
        //                Console.WriteLine("Product removed successfully");
        //                return true;
        //            }
        //            else
        //            {
        //                Console.WriteLine(//what can be errors????to remove product
        //            }
                    
        //        }
        //    }
        //}
        //public void DisplayProductInformation(string productName)
        //{

        //}



    }
}

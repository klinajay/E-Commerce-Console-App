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
        public void AddProductToInventory(Product product)
        {
            if (this.inventoryList.ContainsKey(product.productName))
            {
                //AddExhistingProduct(product);
            }
            else
            {
                this.inventoryList.Add(product.productName, product);
            }
        }

        //public bool RemoveProductFromInventory()
        //{

        //}
        //public Product SearchProductInInventory(string productName)
        //{

        //}
        //public bool ReduceQuantityOfProductFromInventory(string productName) 
        //{

        //}
        //public void DisplayProductInformation(string productName)
        //{

        //}



    }
}

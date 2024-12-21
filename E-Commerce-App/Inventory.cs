using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if(String.IsNullOrEmpty(productName))
            {
                throw new ArgumentException("product name cannot be null or empty.");
            }
            try
            {
                if (this.inventoryList.ContainsKey(productName))
                {
                    this.inventoryList.Remove(productName);
                    Console.WriteLine("Product removed successfully.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while removing product from inventory." , e.Message);
                throw;
                
            }
            
        }

        public static int LevenshteinDistance(string source, string target)
        {
            int n = source.Length;
            int m = target.Length;

            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j <= m; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (source[i - 1] == target[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                    }
                }
            }

            return dp[n, m];
        }

        public  void DisplayParticularProducts(List<string> products)
        {
            foreach(string product  in products)
            {
                Console.WriteLine($"{this.inventoryList[product].productName}        {this.inventoryList[product].availableQuantity}        {this.inventoryList[product].quantityType}        {this.inventoryList[product].ProductPrice}");

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
                List<string> results = new List<string>();
                foreach (KeyValuePair<string, Product> pair in this.inventoryList)
                {
                    int distance = LevenshteinDistance(pair.Key , productName);
                    int maxDistance = Math.Max(productName.Length / 2, pair.Key.Length / 2);

                    if (distance <= maxDistance)
                    {
                        Console.WriteLine(distance);
                        results.Add(pair.Key);
                    }
                }

                DisplayParticularProducts(results);
                //Console.WriteLine("Product Not Found");
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

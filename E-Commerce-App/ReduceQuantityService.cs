using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class ReduceQuantityService
    {
        public bool ReduceQuantityOfProductFromInventory(string productName, double quantity,ref Inventory inventory)
        {
            if (inventory.inventoryList.ContainsKey(productName))
            {
                Product product = SearchProduct(productName , inventory.inventoryList);
                if (product != null)
                {
                    inventory.inventoryList[productName].availableQuantity -= quantity;
                    return true;
                }
                else return false;

            }
            else
            {
                return false;
            }
        }
        public Product SearchProduct(string productName, SortedList<string, Product> inventoryList)
        {
            foreach (var product in inventoryList)
            {
                if (product.Key == productName)
                {
                    return product.Value;
                }
            }
            return null;
        }
        public void OnProductAddedToCart(object source , ProductEventArgs args)
        {
            ReduceQuantityOfProductFromInventory(args.productName, args.quantity ,ref args.inventory);
        }

    }
}

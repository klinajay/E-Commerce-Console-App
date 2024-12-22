using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class OrderList
    {
        List<OnlineOrder> onlineOrderList;

        public OrderList() 
        {
            onlineOrderList = new List<OnlineOrder>();
        }

        public void ViewOrdersOfCustomer( string customerId)
        {
            if(onlineOrderList.Count > 0)
            {
                foreach (var item in onlineOrderList)
                {
                    if (item.GetCustomer().GetCustomerId().Equals(customerId))
                    {
                        foreach (var item2 in item.GetProducts())
                        {
                            Console.WriteLine($"{item2.Key}   {item2.Value}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No orders to show");
            }
        }
    }
}

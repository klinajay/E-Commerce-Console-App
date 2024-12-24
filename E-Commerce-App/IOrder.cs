using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal interface IOrder
    {
        public void ProceedOrder(SortedList<string, Customer> customers, string customerId, SortedList<string, Product> inventory);
        public bool ValidateCustomer(SortedList<string, Customer> customers, string customerId);
        public double CalculateTotal(SortedList<string, Customer> customers, string customerId, SortedList<string, Product> inventory);
        //public void GenerateBill();
        
    }
}

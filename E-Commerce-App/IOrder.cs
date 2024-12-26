using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal interface IOrder
    {
<<<<<<< HEAD
        public void ProceedOrder( string Id);
        public bool ValidateCustomer( string Id);
        public double CalculateTotal(string Id);
=======
        public void ProceedOrder(SortedList<string, Customer> customers, string customerId, SortedList<string, Product> inventory);
        public bool ValidateCustomer(SortedList<string, Customer> customers, string customerId);
        public double CalculateTotal(SortedList<string, Customer> customers, string customerId, SortedList<string, Product> inventory);
        //public void GenerateBill();
        
>>>>>>> 4f687f2896344c5b40baf7845b7fb5ed6986bf66
    }
}

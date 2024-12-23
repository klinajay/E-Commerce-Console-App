using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class CustomerList
    {
        public SortedList<string, Customer> customerList;
        public CustomerList()
        {
            customerList = new SortedList<string, Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null");
            }
            else
            {
                if (customerList.ContainsKey(customer.GetCustomerId()))
                {
                    Console.WriteLine("Customer already exists.");
                }
                else
                {
                    this.customerList.Add(customer.GetCustomerId(), customer);
                    Console.WriteLine("Customer added successfuly");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_App.Models;

namespace E_Commerce_App.Data
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
                if (customerList.ContainsKey(customer.CustomerId))
                {
                    Console.WriteLine("Customer already exists.");
                }
                else
                {
                    customerList.Add(customer.CustomerId, customer);
                    //Console.WriteLine("Customer added successfuly");
                }
            }
        }

        //Other functionality can be added like DeleteAccount and other related to customerList which only admin can perform
    }
}

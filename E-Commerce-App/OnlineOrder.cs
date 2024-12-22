using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class OnlineOrder : InterfaceOrder
    {
        protected Customer customer;
        protected bool paymentStatus;
        protected string paymentId;
        protected double totalBill;

        public OnlineOrder(Customer customer, bool paymentStatus, string paymentId, double totalBill)
        {
            this.customer = customer;
            this.paymentStatus = paymentStatus;
            this.paymentId = paymentId;
            this.totalBill = 0;
        }
        public bool ValidateCustomer(SortedList<string , Customer> customers , string customerId)
        {
            if (customers == null) throw new ArgumentNullException("Not a valid Customer list.");

            try
            {
                if (customers.ContainsKey(customerId)) return true;
                else return false;
            }
            catch
            {
                Console.WriteLine("Something went wrong while validating order credentials");
                throw;
            }
        }
        public void ProceedOrder(SortedList<string, Customer> customers, string customerId)
        {
            Console.WriteLine("Proceeding your order.");
            if (ValidateCustomer(customers, customerId))
            {
                totalBill = CalculateTotal(customers, customerId);
                Console.WriteLine("Order processed successfully");
            }
            else 
            {
                Console.WriteLine("Error while validating customer");
            }

        }

        public double CalculateTotal(SortedList<string, Customer> customers, string customerId)
        {

            Customer c1 = customers[customerId];
            SortedList<string, double> Cart = c1.GetCart();
            double result = 0;
            foreach (KeyValuePair<string , double> item in Cart)
            {
                result += item.Value;
            }
            return result;
        }

    }
}

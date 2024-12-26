using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class OnlineOrder : IOrder
    {
        private Customer customer;
        private bool paymentStatus;
        private string paymentId;
        private double totalBill;
        private SortedList <string , double> products;

        public OnlineOrder(Customer customer, bool paymentStatus, string paymentId)
        {
            this.customer = customer;
            this.paymentStatus = paymentStatus;
            this.paymentId = paymentId;
            this.totalBill = 0;
            products = customer.GetCart();
        }
        public Customer GetCustomer()
        {
            return customer;
        }

        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }

        public bool GetPaymentStatus()
        {
            return paymentStatus;
        }

        public void SetPaymentStatus(bool paymentStatus)
        {
            this.paymentStatus = paymentStatus;
        }

        public string GetPaymentId()
        {
            return paymentId;
        }

        public void SetPaymentId(string paymentId)
        {
            this.paymentId = paymentId;
        }

        public double GetTotalBill()
        {
            return totalBill;
        }

        public void SetTotalBill(double totalBill)
        {
            this.totalBill = totalBill;
        }

        public SortedList<string, double> GetProducts()
        {
            return products;
        }

        public void SetProducts(SortedList<string, double> products)
        {
            this.products = products;
        }

        public bool ValidateCustomer(string customerId)
            
        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
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
<<<<<<< HEAD
        public void ProceedOrder(string customerId)
=======
        public void ProceedOrder(SortedList<string, Customer> customers, string customerId , SortedList<string , Product> inventory)
>>>>>>> 4f687f2896344c5b40baf7845b7fb5ed6986bf66
        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
            Console.WriteLine("Proceeding your order.");
<<<<<<< HEAD
            if (ValidateCustomer( customerId))
            {
                totalBill = CalculateTotal(customerId);
                Console.WriteLine("Order processed successfully");
=======
            Thread.Sleep(1500);
            if (ValidateCustomer(customers, customerId))
            {
                totalBill = CalculateTotal(customers, customerId , inventory);
                Console.WriteLine("validating your payment.");
                Thread.Sleep(2000);
                Console.WriteLine($"Payment of {totalBill} processed successfuly.");
>>>>>>> 4f687f2896344c5b40baf7845b7fb5ed6986bf66
            }
            else 
            {
                Console.WriteLine("Error while validating customer");
            }

        }

<<<<<<< HEAD
        public double CalculateTotal( string customerId)
=======
        public double CalculateTotal(SortedList<string, Customer> customers, string customerId, SortedList<string, Product> inventory)
>>>>>>> 4f687f2896344c5b40baf7845b7fb5ed6986bf66
        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
            Customer c1 = customers[customerId];
            SortedList<string, double> Cart = c1.GetCart();
            double result = 0;
            foreach (KeyValuePair<string , double> item in Cart)
            {
                result += (item.Value * inventory[item.Key].ProductPrice);
            }
            return result;
        }

    }
}

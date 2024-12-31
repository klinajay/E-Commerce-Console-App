
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App.Models
{
    internal class PhysicalOrder
    {
        private Customer customer;
        private bool paymentStatus;
        private double totalBill;
        private SortedList<string, double> products;

        public PhysicalOrder(Customer customer, bool paymentStatus)
        {
            this.customer = customer;
            this.paymentStatus = paymentStatus;
            totalBill = 0;
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

        public bool ValidatePerson(string customerId)

        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
            if (customers == null)
            {
                throw new ArgumentNullException("Not a valid Customer list.");
            }

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

        public void ProceedOrder(string customerId)

        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
            Console.WriteLine(customerId);
            Console.ReadLine();
            Console.WriteLine("Proceeding your order.");
            Thread.Sleep(1500);
            if (ValidatePerson(customerId))
            {
                totalBill = CalculateTotal(customerId);
                Console.WriteLine($"Give {totalBill} rs to the staff.");
                Thread.Sleep(2000);
                Console.WriteLine("Generating your bill.");
                Thread.Sleep(2000);
                Console.WriteLine($"Payment of {totalBill} rs collected successfuly.");

            }
            else
            {
                Console.WriteLine("Error while validating customer");
            }


        }


        public double CalculateTotal(string customerId)
        {
            SortedList<string, Customer> customers = Program.customerList.customerList;
            SortedList<string, Product> inventory = Program.inventory.inventoryList;
            Customer c1 = customers[customerId];
            SortedList<string, double> Cart = c1.GetCart();
            double result = 0;
            foreach (KeyValuePair<string, double> item in Cart)
            {
                result += item.Value * inventory[item.Key].ProductPrice;
            }
            return result;
        }

    }
}

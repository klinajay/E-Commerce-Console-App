﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class VendorOrders : IOrder
    {
        private Vendor vendor;
        private bool paymentStatus;
        private double totalBill;
        private Product product;

        public VendorOrders(Vendor vendor, Product product, bool paymentStatus)
        {
            this.vendor = vendor;
            this.paymentStatus = paymentStatus;
            this.totalBill = 0;
            this.product = product;
        }
        public Vendor GetVendor()
        {
            return vendor;
        }

        public void SetVendor(Vendor vendor)
        {
            this.vendor = vendor;
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

        public  Product GetProduct()
        {
            return product;
        }

        public void SetProduct(Product product)
        {
            this.product = product;
        }

        public bool ValidatePerson(string vendorId)

        {
            SortedList<string, Vendor> vendors = Program.vendorList.vendorList;
            if (vendors == null)
            {
                throw new ArgumentNullException("Not a valid Vendor.");
            }

            try
            {
                if (vendors.ContainsKey(vendorId)) return true;
                else return false;
            }
            catch
            {
                Console.WriteLine("Something went wrong while validating order credentials");
                throw;
            }
        }

        public void ProceedOrder(string vendorId)

        {
            SortedList<string, Vendor> Vendors = Program.vendorList.vendorList;
  
            Console.WriteLine("Proceeding your order.");
            Thread.Sleep(1500);
            if (ValidatePerson(vendorId))
            {
                totalBill = CalculateTotal(vendorId);
                Console.WriteLine($"Give {totalBill} rs to the staff.");
                Thread.Sleep(2000);
                Console.WriteLine("Generating your bill.");
                Thread.Sleep(2000);
                Console.WriteLine($"Payment of {totalBill} rs collected successfuly.");
                var inventory = Program.inventory;

               
                    if (inventory.inventoryList.ContainsKey(product.productName))
                    {

                        inventory.inventoryList[product.productName].availableQuantity += product.availableQuantity;
                        inventory.DisplayAllAvailableProducts();
                    }
                    else
                    {
                        inventory.AddProductToInventory(product);

                    }
                
            }
            else
            {
                Console.WriteLine("Error while validating customer");
            }


        }


        public double CalculateTotal(string vendorId)
        {
            SortedList<string, Vendor> vendors = Program.vendorList.vendorList;
            SortedList<string, Product> inventory = Program.inventory.inventoryList;
            Vendor c1 = vendors[vendorId];
            Product product1= product;
            double result = 0;
            
            result += (product.availableQuantity * product.ProductPrice);
            
            return result;
        }

    }
}

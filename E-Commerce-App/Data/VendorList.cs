using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_App.Models;

namespace E_Commerce_App.Data
{
    internal class VendorList
    {
        public SortedList<string, Vendor> vendorList;

        public VendorList()
        {
            vendorList = new SortedList<string, Vendor>();
        }

        public void AddVendorsToList(Vendor vendor)
        {
            if (vendor == null)
            {
                throw new ArgumentNullException("Vendor cannot be null");
            }
            if (!vendorList.ContainsKey(vendor.VendorId))
            {
                vendorList.Add(vendor.VendorId, vendor);
                //Console.WriteLine("Vendor Added Successfuly.");
            }
            else
            {
                Console.WriteLine("Vendor already exists.");
            }
        }
    }
}

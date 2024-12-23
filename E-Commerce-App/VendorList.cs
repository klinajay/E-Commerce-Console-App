using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class VendorList
    {
        public SortedList<string, Vendor> vendorList;

        public  VendorList()
        {
            vendorList = new SortedList<string, Vendor>();
        }

        public void AddVendorsToList(Vendor vendor)
        {
            if (vendor == null)
            {
                throw new ArgumentNullException("Vendor cannot be null");
            }
            if (!vendorList.ContainsKey(vendor.GetVendorId(true)))
            {
                vendorList.Add(vendor.GetVendorId(true), vendor);
                Console.WriteLine("Vendor Added Successfuly.");
            }
            else
            {
                Console.WriteLine("Vendor already exists.");
            }
        }
    }
}

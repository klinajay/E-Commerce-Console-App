using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class Product
    {
        private double price;
        public string productName;
        public double availableQuantity;
        public string quantityType;

        public double ProductPrice
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public Product(string productName, double availableQuantity, double price, string quantityType)
        {
            this.price = price;
            this.productName = productName;
            this.availableQuantity = availableQuantity;
            this.quantityType = quantityType;
        }



        public bool CheckAvailability(Product product)
        {
            if (availableQuantity == 0) return true;
            else return false;
        }


    }
}

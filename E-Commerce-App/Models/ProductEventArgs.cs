﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_App.Data;

namespace E_Commerce_App.Models
{
    internal class ProductEventArgs : EventArgs
    {
        public string productName;
        public double quantity;
        public Inventory inventory;
        public ProductEventArgs(string productName, double quantity, ref Inventory inventory)
        {
            this.productName = productName;
            this.quantity = quantity;
            this.inventory = inventory;
        }
    }

}

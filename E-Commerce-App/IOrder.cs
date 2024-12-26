using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal interface IOrder
    {

        public void ProceedOrder( string Id);
        public bool ValidatePerson(string Id);
        public double CalculateTotal(string Id);

    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal abstract class AbstractClassPerson
    {
        public string personName;
        protected string email;
        protected string phoneNumber;
        protected int age;
        protected string typeCustormerOrVendor;
        protected string password;
        public abstract string GetEmail(bool isAuthorizd);
        public abstract string GetPhoneNumber(bool isAuthorizd);
        public abstract int GetAge(bool isAuthorizd);
        public abstract string GetTypeCustomerOrVendor(bool isAuthorizd);
        public abstract void SetEmail(string newEmail ,bool isAuthorizd);
        public abstract void SetPhoneNumber(string newPhoneNumber ,bool isAuthorizd);
        public abstract void SetAge(int newAge ,bool isAuthorizd);
        public abstract void SetTypeCustomerOrVendor(string newType, bool isAuthorizd);
        public abstract void SetPassword(string newPassword ,bool isAuthorizd);

    }
}

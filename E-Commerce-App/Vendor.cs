﻿namespace E_Commerce_App
{
    internal class Vendor : Person
    {
        
        private string vendorId;
        

        public Vendor(String name, string email, string phone, string password, string type, int age, string userName)
        {
            personName = name;
            
            SetEmail(email, true);
            SetPhoneNumber(phone, true);
            SetAge(age, true);
            SetPassword(password, true);
            SetRoleType(type, true);
            vendorId = userName;
        }
        
        
        public override string GetEmail(bool isAuthorized)
        {
            return isAuthorized ? email : "Authorization required!";
        }
        public string GetVendorId(bool isAuthorized)
        {
            return vendorId;
        }
        public override string GetPhoneNumber(bool isAuthorized)
        {
            return isAuthorized ? phoneNumber : "Authorization required!";
        }

        public override int GetAge(bool isAuthorized)
        {
            return isAuthorized ? age : -1; // Returning -1 to indicate lack of authorization
        }

        public override string GetRoleType(bool isAuthorized)
        {
            return isAuthorized ? roleType : "Authorization required!";
        }

        public override void SetEmail(string newEmail, bool isAuthorized)
        {
            if (isAuthorized)
            {
                email = newEmail;
              
            }
            else
            {
                Console.WriteLine("Authorization required to update email.");
            }
        }

        public override void SetPhoneNumber(string newPhoneNumber, bool isAuthorized)
        {
            if (isAuthorized)
            {
                phoneNumber = newPhoneNumber;
               
            }
            else
            {
                Console.WriteLine("Authorization required to update phone number.");
            }
        }
        
        public void AddProductToRequestList(Product product , SortedList<Vendor , VendorOrders> RequestList)
        {
            VendorOrders vendorClass = new VendorOrders(this,product, false);
            RequestList.Add(this, vendorClass);
        }

        public override void SetAge(int newAge, bool isAuthorized)
        {
            if (isAuthorized)
            {
                age = newAge;
            }
            else
            {
                Console.WriteLine("Authorization required to update age.");
            }
        }

        public override void SetRoleType(string newType, bool isAuthorized)
        {
            if (isAuthorized)
            {
                roleType = newType;
            }
            else
            {
                Console.WriteLine("Authorization required to update type.");
            }
        }
        public override void SetPassword(string newPassword, bool isAuthorized)
        {
            if (isAuthorized)
            {
                password = newPassword;
            }
            else
            {
                Console.WriteLine("Authorization required to update password.");
            }
        }
        
        //public void SupplyProductToInventory(Product)
        //{

        //}
    }
}

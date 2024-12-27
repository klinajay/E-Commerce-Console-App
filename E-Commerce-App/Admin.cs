using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal class Admin : Person
    {
        
        private string adminId;


        public Admin(String name, string email, string phone, string password, string type, int age, string userName)
        {
            personName = name;
        
            SetEmail(email, true);
            SetPhoneNumber(phone, true);
            SetAge(age, true);
            SetPassword(password, true);
            SetRoleType(type, true);
            adminId = userName;
        }
        
        
        public override string GetEmail(bool isAuthorized)
        {
            return isAuthorized ? email : "Authorization required!";
        }
        public string GetAdminId(bool isAuthorized)
        {
            return adminId;
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

        public void ApproveOrders(SortedList<Vendor, VendorOrders> requestList)
        {
            if (requestList == null)
            {
                Console.WriteLine("No orders to approve.");
                return;
            }
            else
            {
                foreach (var entry in requestList)
                {
                    Console.WriteLine("Order approved for vendor: " + entry.Key.GetVendorId(true));
                    entry.Value.ProceedOrder(entry.Key.GetVendorId(true));
                }
            }
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
        
    }
}

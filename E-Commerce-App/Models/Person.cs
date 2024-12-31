using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App.Models
{
    internal abstract class Person
    {
        public string PersonName;
        public string? Email;
        public string? PhoneNumber;
        public int? Age;
        public string RoleType;
        public string Password;
       
        public bool Login(string password, string username)
        {
            if(string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Please enter a valid  password.");
                return false;
            }
            if (this.Password == password)
            {
                Console.WriteLine("Logging in.....");
                Thread.Sleep(5000);
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password or username.");
                return false;
            }
        }
        public void ShowProfile()
        {
            Console.WriteLine($"${RoleType} name is: {PersonName}");
            Console.WriteLine($"${RoleType} email is: {Email}");
            Console.WriteLine($"${RoleType} phone number is: {PhoneNumber}");
            Console.WriteLine($"${RoleType} age is: {Age}");

        }

    }
}

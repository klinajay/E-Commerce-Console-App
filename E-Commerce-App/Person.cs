using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    internal abstract class Person
    {
        public string personName;
        protected string email;
        protected string phoneNumber;
        protected int age;
        protected string roleType;
        protected string password;
        public abstract string GetEmail(bool isAuthorizd);
        public abstract string GetPhoneNumber(bool isAuthorizd);
        public abstract int GetAge(bool isAuthorizd);
        public abstract string GetRoleType(bool isAuthorizd);
        public abstract void SetEmail(string newEmail ,bool isAuthorizd);
        public abstract void SetPhoneNumber(string newPhoneNumber ,bool isAuthorizd);
        public abstract void SetAge(int newAge ,bool isAuthorizd);
        public abstract void SetRoleType(string newType, bool isAuthorizd);
        public abstract void SetPassword(string newPassword ,bool isAuthorizd);
        public async void Login(string password , string username ) 
        {

            if (this.password == password)
            {
                Console.WriteLine("Logging in.....");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Incorrect password or username.");
            }
        }
        public void ShowProfile()
        {
            Console.WriteLine($"${roleType} name is: {personName}");
            Console.WriteLine($"${roleType} email is: {email}");
            Console.WriteLine($"${roleType} phone number is: {phoneNumber}");
            Console.WriteLine($"${roleType} age is: {age}");
            
        }

    }
}

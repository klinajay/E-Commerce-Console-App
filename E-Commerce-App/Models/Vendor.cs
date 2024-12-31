namespace E_Commerce_App.Models
{
    internal class Vendor : Person
    {

        public string VendorId;


        public Vendor(string name, string email, string phone, string password, string type, int age, string userName)
        {
            PersonName = name;
            Email = email;
            PhoneNumber = phone;
            Age = age;
            Password = password;
            RoleType = type;
            VendorId = userName;
        }


        
        
        
      
        public void AddProductToRequestList(Product product, SortedList<Vendor, VendorOrders> RequestList)
        {
            VendorOrders vendorClass = new VendorOrders(this, product, false);
            RequestList.Add(this, vendorClass);
        }

       
       

        //public void SupplyProductToInventory(Product)
        //{

        //}
    }
}

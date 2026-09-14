using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public class Customer : People
    {
        static private List<Customer> CustomersDataBase = new List<Customer>();

        
        private int ID = -1;
        
        private List<Vehicle> OwnedVehicle = new List<Vehicle>();

        public Customer(string _name, int _age, string _phoneNumber, string _job)
        {
            this.name = _name;
            this.age = _age;
            this.phoneNumber = _phoneNumber;
            this.job = _job;
        }
    }
    
    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public class Customer 
    {
        static private List<Customer> CustomersDataBase = new List<Customer>();

        
        private int ID = -1;
        public string name { get; }
        private int? age { get; }
        private string? phoneNumber { get; }
        private string? job { get; }

        private List<Vehicle> OwnedVehicle = new List<Vehicle>();

        public Customer(int _id, string _name, int _age, string _phoneNumber, string _job)
        {
            this.ID = _id;
            this.name = _name;
            this.age = _age;
            this.phoneNumber = _phoneNumber;
            this.job = _job;

            CustomersDataBase.Add(this);

        }


        public void AttachCustomerToVehicle(Vehicle _vehicle)
        {

            OwnedVehicle.Add(_vehicle );
            _vehicle.AttachVehicleToCustomer(this);

        }
        
        public List<Vehicle> GetCustomerVehicles()
        {
            return OwnedVehicle;
        }
    }
    
    
}

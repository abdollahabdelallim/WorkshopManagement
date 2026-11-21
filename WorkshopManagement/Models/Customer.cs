using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace WorkshopManagement.Models
{
    public class Customer
    {
        static IDGenerator? CustomerIdGenerator = IDGenerator.CreateNewIDGenerator(0, 90000);
        internal static List<Customer> CustomersDataBase = new List<Customer>();
        private int ID;
        internal string name { get; private set; }
        private int? age { get; }
        private string? phoneNumber { get; }
        private string? job { get; }

        private List<Vehicle> OwnedVehicle = new List<Vehicle>();

        private Customer(int _id, string _name, int _age, string _phoneNumber, string _job)
        {
            this.ID = _id;
            this.name = _name;
            this.age = _age;
            this.phoneNumber = _phoneNumber;
            this.job = _job;
        }
        internal static Customer? CreateNewCustomer(string _name, int _age, string _phoneNumber, string _job)
        {

            if (CustomerIdGenerator != null)
            {

                int? id = CustomerIdGenerator.GenerateID();
                if (id != null && SearchForCustomer((int)id) == null)
                {

                    Customer newCustomer = new Customer((int)id, _name, _age, _phoneNumber, _job);
                    CustomersDataBase.Add(newCustomer);
                    return newCustomer;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }


        }
        public string GetName()
        {
            return this.name;
        }
        internal void AddVehicleToCustomerCollection(Vehicle _vehicle)
        {
            if (!OwnedVehicle.Contains(_vehicle))
            {
                OwnedVehicle.Add(_vehicle);
            }
        }

        internal List<string> GetCustomerVehiclesVIN()
        {
            List<string> listOfVIN = new List<string>();
            foreach (var car in OwnedVehicle)
            {
                string? _vin = car.GetVIN();

                if (_vin != null)
                {
                    listOfVIN.Add(_vin);
                }
            }
            return listOfVIN;
        }
        internal List<string> GetCustomerVehiclesModels()
        {
            List<string> listOfModels = new List<string>();

            foreach (var car in OwnedVehicle)
            {
                string? _model = car.GetModel();

                if (_model != null)
                {
                    listOfModels.Add(_model);
                }
            }
            return listOfModels;

        }

        internal static Customer? SearchForCustomer(string _customerName)
        {
            return CustomersDataBase.FirstOrDefault(c => c.name.Equals(_customerName, StringComparison.OrdinalIgnoreCase));
        }
        internal static Customer? SearchForCustomer(int _customerID)
        {
            return CustomersDataBase.FirstOrDefault(c => c.ID.Equals(_customerID));
        }
        internal void RemoveVehicle(Vehicle _vehicle)
        {
            if (OwnedVehicle.Contains(_vehicle))
            {
                OwnedVehicle.Remove(_vehicle);
            }
        }

        internal bool IsOwnVehicle(Vehicle _vehicle)
        {
            return OwnedVehicle.Contains(_vehicle);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public class Vehicle
    {
        static List<Vehicle> VehicleDataBase = new List<Vehicle>();
        public static void AddVehicleToDataBase(Vehicle v)
        {
            VehicleDataBase.Add(v);
        }


        private int milage;
        private string? vin;
        private string? model;
        private string? bodyCode;
        private string? paintCode;
        private string? lisensePlate;
        private DateOnly? registerDate;
        private Customer? owner;

        public Vehicle(int _milage, string _vin, string _model, string _bodyCode, Customer? _owner, string? _paintCode = null, string? _lisensePlate = null, DateOnly? _registerDate = null)
        {
            this.milage = _milage;
            this.vin = _vin;
            this.model = _model;
            this.bodyCode = _bodyCode;
            this.paintCode = _paintCode;
            this.lisensePlate = _lisensePlate;
            this.registerDate = _registerDate;
            this.owner = _owner;

            VehicleDataBase.Add(this);
        }

        

        public int GetMilage()
        {
            return this.milage;
        }
        public string? GetVIN() { return this.vin; }
        public string? GetModel() {return this.model; }
        public void AttachVehicleToCustomer(Customer _owner)
        {
            owner = _owner;
        }
        public bool SearchForVehicle()
        {
            return 
        }

    }
}

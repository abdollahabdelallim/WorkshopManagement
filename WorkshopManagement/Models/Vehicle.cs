using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public class Vehicle
    {
        internal static List<Vehicle> VehicleDataBase = new List<Vehicle>();

        public int milage { get; private set; }
        public string vin { get; private set; }
        public string? model { get; private set; }
        public string? bodyCode { get; private set; }
        public string? paintCode { get; private set; }
        internal string? lisensePlate { get; private set; }
        internal DateOnly? registerDate { get; private set; }
        internal Customer? Owner { get; private set; }

        private Vehicle(int _milage, string _vin, string _model, string _bodyCode, Customer? _owner, string? _paintCode = null, string? _lisensePlate = null, DateOnly? _registerDate = null)
        {
            this.vin = _vin;
            this.milage = _milage;
            this.model = _model;
            this.bodyCode = _bodyCode;
            this.paintCode = _paintCode;
            this.lisensePlate = _lisensePlate;
            this.registerDate = _registerDate;
            this.Owner = _owner;
        }

        public static Vehicle? CreateNewVehicle(int _milage, string _vin, string _model, string _bodyCode, Customer? _owner, string? _paintCode = null, string? _lisensePlate = null, DateOnly? _registerDate = null)
        {
            if (SearchForVehicle(_vin) == null)
            {
                Vehicle newVehicle = new Vehicle(_milage, _vin, _model, _bodyCode, _owner, _paintCode, _lisensePlate, _registerDate);
                if (_owner != null)
                {
                    _owner.AddVehicleToCustomerCollection(newVehicle);

                }
                VehicleDataBase.Add(newVehicle);
                return newVehicle;
            }
            else
            {
                return null;//dont create the object
            }
        }

        public int GetMilage()
        {
            return this.milage;
        }
        public string? GetVIN() { return this.vin; }
        public string? GetModel() {return this.model; }
        internal Customer? GetOwner() {return this.Owner; }
        internal void LinkToOwner(Customer _owner){this.Owner = _owner;}
        internal void RemoveOwner(){this.Owner = null;}
        internal static Vehicle? SearchForVehicle(string _vin)
        {
            return VehicleDataBase.FirstOrDefault(v => v.vin.Equals(_vin,StringComparison.OrdinalIgnoreCase));
        }

    }
}

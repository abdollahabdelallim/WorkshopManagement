using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public static class CustomerVehicleCoordinator
    {
        public static void MoveVehicleToNewCustomer(Customer newOwner, Vehicle vehicle)
        {
            var oldOwner = vehicle.GetOwner();
            if (oldOwner != null && newOwner != null && vehicle != null)
            {
                if (oldOwner.GetCustomerVehiclesVIN().Contains(vehicle.vin))
                {
                    oldOwner.RemoveVehicle(vehicle);
                    newOwner.AddVehicleToCustomerCollection(vehicle);
                    vehicle.LinkToOwner(newOwner);
                }
            }
        }
    }
}


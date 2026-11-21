using System.Runtime.Serialization;
using WorkshopManagement.Models;
using static WorkshopManagement.Models.WorkOrder;



Customer? ahmed   = Customer.CreateNewCustomer("Ahmed"  , 23,"01067452213","Doctor"      );
Customer? mohamed = Customer.CreateNewCustomer("Mohamed", 35,"01062552213","Buisness Man");
Customer? maged   = Customer.CreateNewCustomer("Maged"  , 33,"01146887988","Pilot"       );

Vehicle? bmw1 = Vehicle.CreateNewVehicle(24121,"y500487","X5","G05", ahmed);
Vehicle? bmw2 = Vehicle.CreateNewVehicle(24121,"y500481","X7","G07", ahmed);
Vehicle? bmw3 = Vehicle.CreateNewVehicle(24121,"y500482","320","G20", mohamed);

if (maged != null)
{
    Console.WriteLine("Customer Name: " + maged.name);
    foreach (var v in maged.GetCustomerVehiclesModels())
    {
        Console.WriteLine("Vehicle1: " + v);
    }

}
if (ahmed != null)
{
    Console.WriteLine("Customer Name: " + ahmed.name);
    foreach (var v in ahmed.GetCustomerVehiclesModels())
    {
        Console.WriteLine("Vehicle1: " + v);
    }

}
if(mohamed != null)
{
    Console.WriteLine("Customer Name: " + mohamed.name);
    foreach (var v in mohamed.GetCustomerVehiclesModels())
    {
        Console.WriteLine("Vehicle2: " + v);
    }
    if (bmw2 != null)
    {
        CustomerVehicleCoordinator.MoveVehicleToNewCustomer(mohamed, bmw2);
    }
    Console.WriteLine("Customer Name: " + mohamed.name);
    foreach (var v in mohamed.GetCustomerVehiclesModels())
    {
        Console.WriteLine("Vehicle3: " + v);
    }

}

if (ahmed != null)
{
    Console.WriteLine("Customer Name: " + ahmed.name);
    foreach (var v in ahmed.GetCustomerVehiclesModels())
    {
        Console.WriteLine("Vehicle1: " + v);
    }

}
Console.WriteLine("---------");

Console.WriteLine("All Vehicle in the DataBase");
foreach (var v in Vehicle.VehicleDataBase)
{
    Console.WriteLine("Vehicle1: " + v.GetModel());


}

Console.WriteLine("All Customers in the DataBase");
foreach (var c in Customer.CustomersDataBase)
{
    Console.WriteLine("Customer: " + c.name);

}
Console.WriteLine("---------");

if(mohamed != null)
{
    if(mohamed.GetCustomerVehiclesVIN().Any())
    {
        Vehicle? v = Vehicle.SearchForVehicle((mohamed.GetCustomerVehiclesVIN()[0]));
        if (v != null && mohamed.IsOwnVehicle(v))
        {
            WorkOrder? workorder1 = WorkOrder.CreateNewWorkOrder(mohamed, v, "i hear groaning noise while shifting up");
            if (workorder1 != null)
            {
                if (!workorder1.ChangeJobStatus(WorkOrderStatuses.InProgress))
                {
                    Console.WriteLine("1 cant do this change directly");
                }

            }

            WorkOrder? workorder2 = WorkOrder.CreateNewWorkOrder(mohamed, v, "i hear groaning noise while shifting up");
            if (workorder2 != null)
            {
                if (!workorder2.ChangeJobStatus(WorkOrderStatuses.Complete))
                {
                    Console.WriteLine("2 cant do this change directly");
                }

            }
        }
    }
    
    
}


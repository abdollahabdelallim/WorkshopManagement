using WorkshopManagement.Models;



Customer customer = new Customer
(10001,"Ahmed",5,"01067452213","Doctor");

Vehicle car = new Vehicle(24122,"y500487","X5","G05",customer );


customer.AttachCustomerToVehicle(car);
Console.WriteLine("Customer Name: "+customer.name);
foreach(var v in customer.GetCustomerVehicles())
{
Console.WriteLine("Vehicle1: " + v.GetModel());
}

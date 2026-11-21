using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public class WorkOrder
    {
        internal static List<WorkOrder> WorkOrdersDataBase = new List<WorkOrder>();
        internal static IDGenerator? WorkOrderNumberGenerator = IDGenerator.CreateNewIDGenerator(0, 90000);
        internal enum WorkOrderStatuses
        {
            New = 0,
            Complete,
            InProgress,
            Canceled,
            Closed
        }
        internal int milage { get; }
        internal int workOrderNumber { get; }
        internal string customerComplaint { get; }
        internal DateTime enteringDate { get; }
        internal WorkOrderStatuses Status { get; private set; }


        internal Customer customer { get; }
        internal Vehicle vehicle { get; }

        private WorkOrder(int _workOrderNumber, Customer _customer, Vehicle _vehicle, string _customerComplaint)
        {
            this.customer = _customer;
            this.vehicle = _vehicle;
            this.milage = vehicle.GetMilage();
            this.workOrderNumber = _workOrderNumber;
            this.customerComplaint = _customerComplaint;
            this.enteringDate = DateTime.Now;
            this.Status = WorkOrderStatuses.New;

        }

        internal static WorkOrder? CreateNewWorkOrder(Customer? _customer, Vehicle? _vehicle, string _customerComplaint="")
        {
            if (_vehicle == null || _customer == null || !_customer.IsOwnVehicle(_vehicle) || WorkOrderNumberGenerator == null)
            {
                return null;
            }
            else
            {

                int? workOrderNum = WorkOrderNumberGenerator.GenerateID();
                if (workOrderNum != null)
                {
                    WorkOrder newWorkOrder = new WorkOrder((int)workOrderNum, _customer, _vehicle, _customerComplaint);
                    WorkOrdersDataBase.Add(newWorkOrder);
                    return newWorkOrder;
                }
                else
                {
                    return null;
                }

            }
        }

        internal static WorkOrder? SearchForWorkOrder(int _workOrderNumber)
        {
            return WorkOrdersDataBase.FirstOrDefault(x => x.workOrderNumber == _workOrderNumber);
        }

        internal bool ChangeJobStatus(WorkOrderStatuses _status)
        {
            if (Status == WorkOrderStatuses.Closed || Status == WorkOrderStatuses.Canceled)
            {
                return false;
            }
            else if(Status ==WorkOrderStatuses.Complete)
            {
                if (_status == WorkOrderStatuses.Closed)
                {
                    this.Status = _status;
                    return true;
                }
                else return false;
            }
            else if (this.Status == WorkOrderStatuses.New)
            {
                if (_status != WorkOrderStatuses.Closed && _status != WorkOrderStatuses.Complete)
                {
                    if (Enum.IsDefined(typeof(WorkOrderStatuses), _status))
                    {
                        this.Status = _status;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                if (_status != WorkOrderStatuses.New)
                {
                    if (Enum.IsDefined(typeof(WorkOrderStatuses), _status))
                    {
                        this.Status = _status;
                        return true;
                    }
                    else return false;
                }
                else return false;
                
            }
        }
    }
}

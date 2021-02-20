using System.Collections.Generic;
using HPlusSports.Core;
using HPlusSports.Models;

namespace HPlusSports.Web.ViewModels
{
    // inherit should be the first in the seq
    // allow multi interface 
    // extension can be derived to the model implemented the interface
    public class OrderItemViewModel : Order, IOrderItemViewModel, IOrderItemViewModel2
    {
        public OrderItemViewModel(IEnumerable<Order> orders, Order o)
        {
            base.CreatedDate = o.CreatedDate;
            base.Customer = o.Customer;
            base.CustomerId = o.CustomerId;
            base.Deleted = o.Deleted;
            base.Id = o.Id;
            base.OrderDate = o.OrderDate;
            base.OrderItem = o.OrderItem;
            base.Salesperson = o.Salesperson;
            base.SalespersonId = o.SalespersonId;
            base.Status = o.Status;
            base.TotalDue = o.TotalDue;

            PreviousOrderDates = string.Join("\n",
                        orders.FilterdSelect(
                            o => o.CustomerId == CustomerId
                            && o.OrderDate < base.OrderDate
                            , o => o.OrderDate.ToString("d")
                        ));
        }

        public string CustomerName => Customer.FirstName + " " + Customer.LastName;
        public new string TotalDue => base.TotalDue?.ToString("f2");
        public new string OrderDate => base.OrderDate.ToString("d");
        public string PreviousOrderDates { get; private set; }

        public int CustomerId2 => throw new System.NotImplementedException();

        public string CustomerName2 => throw new System.NotImplementedException();

        public string Status2 => throw new System.NotImplementedException();
    }

    public interface IOrderItemViewModel
    {
        int CustomerId { get; }
        string CustomerName { get; }
        string Status { get; }
        string TotalDue { get; }
        string OrderDate { get; }
        string PreviousOrderDates { get; }
    }

    public interface IOrderItemViewModel2
    {
        int CustomerId2 { get; }
        string CustomerName2 { get; }
        string Status2 { get; }
    }

    // Extension method on interface
    public static class IOrderItemViewModel2Extension{
        public static string OrderFullName(this IOrderItemViewModel2 model2){
            return model2.CustomerName2 + model2.Status2;
        }

    }
}
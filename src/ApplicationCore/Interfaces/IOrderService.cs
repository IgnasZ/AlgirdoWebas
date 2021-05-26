using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int id, Address address, string checkoutMethod, DateTime courierArrivalTime, string recipientName, string recipientSurname, string recipientPhoneNo);
    }
}

using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDTO order);
        Task CancelOrder(int orderId);
        Task GetOrderDetails(int orderId);
    }
}

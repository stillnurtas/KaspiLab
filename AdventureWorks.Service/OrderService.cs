using AdventureWorks.DTO.Models.BL;
using AdventureWorks.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service
{
    public class OrderService : IOrderService
    {
        public Task CancelOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrder(BasketDTO basket)
        {
            throw new NotImplementedException();
        }

        public Task GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}

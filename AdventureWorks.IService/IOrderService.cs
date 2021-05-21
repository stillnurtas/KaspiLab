using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.IService
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Task CreateOrder(BasketDTO basket);

        [OperationContract]
        Task CancelOrder(int orderId);

        [OperationContract]
        Task GetOrderDetails(int orderId);
    }
}

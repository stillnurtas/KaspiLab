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
    public interface ISalesService
    {
        [OperationContract]
        Task SetSalesPerson(OrderDTO order);

        [OperationContract]
        Task ReserveOrderProducts(OrderDTO order);

        [OperationContract]
        Task ExecuteOrder();
    }
}

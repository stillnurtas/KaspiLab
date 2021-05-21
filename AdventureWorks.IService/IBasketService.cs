using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.IService
{
    [ServiceContract]
    public interface IBasketService
    {
        [OperationContract]
        Task AddProductIntoBasket(string basketId, int productId, int quantity = 1);

        [OperationContract]
        Task RemoveProductFromBasket(string basketId, int productId, int quantity = 1);

        [OperationContract]
        Task ClearBasketAsync(string basketId);

        [OperationContract]
        Task AddProductIntoSession();

        [OperationContract]
        Task RemoveProductFromSession();
    }
}

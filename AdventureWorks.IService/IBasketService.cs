using AdventureWorks.BL.Infrastructure;
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
    public interface IBasketService
    {
        [OperationContract]
        Task<OperationDetails> AddProduct(string basketId, int productId, int quantity = 1);

        [OperationContract]
        Task<OperationDetails> RemoveProduct(string basketId, int productId, int quantity = 1);

        [OperationContract]
        Task<OperationDetails> ClearBasket(string basketId);

        [OperationContract]
        Task<BasketDTO> GetBasketItems(string basketId);

        [OperationContract]
        Task<string> GenerateBasketId();
    }
}

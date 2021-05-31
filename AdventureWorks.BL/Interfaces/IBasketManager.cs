using AdventureWorks.BL.Infrastructure;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IBasketManager
    {
        Task<OperationDetails> AddProduct(string basketId, int productId, int quantity = 1);
        Task<OperationDetails> RemoveProduct(string basketId, int productId, int quantity = 1);
        Task<OperationDetails> ClearBasket(string basketId);
        Task<BasketDTO> GetBasketItems(string basketId);
        Task<string> GenerateBasketId();
    }
}

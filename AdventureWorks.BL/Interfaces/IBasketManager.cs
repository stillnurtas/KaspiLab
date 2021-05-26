using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IBasketManager
    {
        Task AddProduct(string basketId, int productId, int quantity = 1);
        Task RemoveProduct(string basketId, int productId, int quantity = 1);
        Task ClearBasket(string basketId);
        Task<BasketDTO> GetBasketItems(string basketId);
    }
}

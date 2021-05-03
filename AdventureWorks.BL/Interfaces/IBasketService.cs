using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IBasketService
    {
        Task AddProductIntoBasket(string basketId, int productId, int quantity = 1);
        Task RemoveProductFromBasket(string basketId, int productId, int quantity = 1);
        Task ClearBasketAsync(string basketId);
        Task AddProductIntoSession();
        Task RemoveProductFromSession();
    }
}

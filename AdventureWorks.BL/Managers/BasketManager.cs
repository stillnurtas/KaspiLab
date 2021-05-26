using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Managers
{
    public class BasketManager : IBasketManager
    {
        public Task AddProduct(string basketId, int productId, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public Task ClearBasket(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketDTO> GetBasketItems(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProduct(string basketId, int productId, int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}

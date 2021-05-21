using AdventureWorks.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service
{
    public class BasketService : IBasketService
    {
        public Task AddProductIntoBasket(string basketId, int productId, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public Task AddProductIntoSession()
        {
            throw new NotImplementedException();
        }

        public Task ClearBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromBasket(string basketId, int productId, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromSession()
        {
            throw new NotImplementedException();
        }
    }
}

using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
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
        private readonly IBasketManager basketMng;

        public async Task AddProduct(string basketId, int productId, int quantity = 1)
        {
            await basketMng.AddProduct(basketId, productId, quantity);
        }

        public async Task ClearBasket(string basketId)
        {
            await basketMng.ClearBasket(basketId);
        }

        public async Task<BasketDTO> GetBasketItems(string basketId)
        {
            return await basketMng.GetBasketItems(basketId);
        }

        public async Task RemoveProduct(string basketId, int productId, int quantity = 1)
        {
            await basketMng.RemoveProduct(basketId, productId, quantity);
        }
    }
}

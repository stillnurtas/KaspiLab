using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.BL.Managers;
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

        public BasketService()
        {
            basketMng = new BasketManager();
        }

        public async Task<OperationDetails> AddProduct(string basketId, int productId, int quantity = 1)
        {
            return await basketMng.AddProduct(basketId, productId, quantity);
        }

        public async Task<OperationDetails> ClearBasket(string basketId)
        {
            return await basketMng.ClearBasket(basketId);
        }

        public async Task<string> GenerateBasketId()
        {
            return await basketMng.GenerateBasketId();
        }

        public async Task<BasketDTO> GetBasketItems(string basketId)
        {
            return await basketMng.GetBasketItems(basketId);
        }

        public async Task<OperationDetails> RemoveProduct(string basketId, int productId, int quantity = 1)
        {
            return await basketMng.RemoveProduct(basketId, productId, quantity);
        }
    }
}

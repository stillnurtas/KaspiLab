using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Managers
{
    public class BasketManager : IBasketManager
    {
        private readonly IUnitOfWork _uow;

        public async Task AddProduct(string basketId, int productId, int quantity = 1)
        {
            var product = await _uow.ShoppingCartItem.GetList(l => l.ShoppingCartID == basketId && l.ProductID == productId);
            if(product == null)
            {
                var lastCartId = await Task.Run(() => _uow.ShoppingCartItem.GetMaxCartId());
                _uow.ShoppingCartItem.Create(new ShoppingCartItem
                {
                    ShoppingCartID = Convert.ToString(lastCartId++),
                    Quantity = quantity,
                    ProductID = productId,
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });

                await _uow.Save();
            }
            else
            {
                _uow.ShoppingCartItem.Create(new ShoppingCartItem
                {
                    ShoppingCartID = basketId,
                    Quantity = quantity,
                    ProductID = productId,
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });

                await _uow.Save();
            }
        }

        public async Task RemoveProduct(string basketId, int productId, int quantity = 1)
        {
            var product = await _uow.ShoppingCartItem.GetList(l => l.ShoppingCartID == basketId && l.ProductID == productId);
            if(product != null)
            {
                product.FirstOrDefault().Quantity -= quantity;
                await _uow.Save();
            }
        }

        public async Task ClearBasket(string basketId)
        {
            var basketItems = await _uow.ShoppingCartItem.GetList(m => m.ShoppingCartID == basketId);
            _uow.ShoppingCartItem.DeleteRange(basketItems);
            await _uow.Save();
        }

        public async Task<BasketDTO> GetBasketItems(string basketId)
        {
            var basket = new BasketDTO();
            var basketItems = await _uow.ShoppingCartItem.GetBasketItems(basketId);

            basketItems.ForEach(item => {
                if (!basket.Items.Keys.Contains(item.Product.Name))
                {
                    basket.Items.Add(item.Product.Name, item);
                }
                else
                {
                    var dict = basket.Items.FirstOrDefault(i => i.Key == item.Product.Name);
                    dict.Value.Quantity += item.Quantity;
                }
            });

            return basket;
        }
    }
}

using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.UnitOfWork;
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

        public BasketManager()
        {
            _uow = new AWUnitOfWork(new AWContext());
        }

        public async Task<OperationDetails> AddProduct(string basketId, int productId, int quantity = 1)
        {
            try
            {
                var product = await _uow.ShoppingCartItem.Get(l => l.ShoppingCartID == basketId && l.ProductID == productId);
                if (product == null)
                {
                    var lastCartId = await _uow.ShoppingCartItem.GetMaxCartId();
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
                else
                {
                    product.Quantity += quantity;
                    await _uow.Save();
                }

                return new OperationDetails(OperationDetails.Statuses.Success, "Success operation", "AddProduct");
            }
            catch(Exception ex)
            {
                return new OperationDetails(OperationDetails.Statuses.Error, ex.Message, "AddProduct");
            }
        }

        public async Task<OperationDetails> RemoveProduct(string basketId, int productId, int quantity = 1)
        {
            try
            {
                var product = await _uow.ShoppingCartItem.GetList(l => l.ShoppingCartID == basketId && l.ProductID == productId);
                if (product != null)
                {
                    product.FirstOrDefault().Quantity -= quantity;
                    await _uow.Save();
                }

                return new OperationDetails(OperationDetails.Statuses.Success, "Success operation", "RemoveProduct");
            }
            catch(Exception ex)
            {
                return new OperationDetails(OperationDetails.Statuses.Error, ex.Message, "RemoveProduct");
            }
        }

        public async Task<OperationDetails> ClearBasket(string basketId)
        {
            try
            {
                var basketItems = await _uow.ShoppingCartItem.GetList(m => m.ShoppingCartID == basketId);
                _uow.ShoppingCartItem.DeleteRange(basketItems);
                await _uow.Save();

                return new OperationDetails(OperationDetails.Statuses.Success, "Success operation", "ClearBasket");
            }
            catch(Exception ex)
            {
                return new OperationDetails(OperationDetails.Statuses.Error, ex.Message, "ClearBasket");
            }
        }

        public async Task<BasketDTO> GetBasketItems(string basketId)
        {
            var basket = new BasketDTO();
            var basketItems = await _uow.ShoppingCartItem.GetBasketItems(basketId);
            basketItems.ForEach(item => {
                var product = basket.Basket.Find(f => f.ProductID == item.ProductID);
                if (product == null)
                {
                    basket.Basket.Add(new ShoppingCartDTO { ProductID = item.ProductID, 
                                                            ProductName = item.Product.Name,
                                                            Quantity = item.Quantity,
                                                            Price = item.Product.StandardCost});
                    basket.TotalPrice += item.Product.StandardCost;
                }
                else
                {
                    var existItem = basket.Basket.FirstOrDefault(i => i.ProductID == item.Product.ProductID);
                    existItem.Quantity += item.Quantity;
                    existItem.Price += item.Product.StandardCost;
                    basket.TotalPrice += existItem.Price;
                }
            });

            return basket;
        }

        public async Task<string> GenerateBasketId()
        {
            var id = await _uow.ShoppingCartItem.GetMaxCartId();
            id++;
            return id.ToString();
        }
    }
}

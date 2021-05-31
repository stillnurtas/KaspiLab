using AdventureWorks.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using AdventureWorks.Repository.UnitOfWork;
using AdventureWorks.DTO.Models.BL;
using System.Data.Entity;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Repositories;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.CustomIdentity;
using AdventureWorks.Auth.IdentityManagers;
using Microsoft.AspNet.Identity;

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        public static AWContext AWContext { get; private set; }

        static void Main(string[] args)
        {
            GetBasketItems("20621").GetAwaiter().GetResult();
        }

        public static async Task<BasketDTO> GetBasketItems(string basketId)
        {
            var basket = new BasketDTO();
            using(AWUnitOfWork uow = new AWUnitOfWork(new AWContext()))
            {
                var basketItems = await uow.ShoppingCartItem.GetBasketItems(basketId);

                try
                {
                    foreach (var item in basketItems)
                    {
                        if (!basket.Items.Keys.Contains(item.Product.Name))
                        {
                            basket.Items.Add(item.Product.Name, item);
                        }
                        else
                        {
                            var dict = basket.Items.FirstOrDefault(i => i.Key == item.Product.Name);
                            dict.Value.Quantity += item.Quantity;
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }

            return basket;
        }
    }
}
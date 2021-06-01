using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Helpers
{
    public static class BasketHelper
    {
        public static async Task<bool> ProductAvailability(ShoppingCartItem cartItem, IUnitOfWork uow)
        {
            var inventory = await uow.ProductInventory.Get(g => g.ProductID == cartItem.ProductID);
            return inventory.Quantity > cartItem.Quantity ? true : false;
        }
    }
}

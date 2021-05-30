﻿using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Interfaces
{
    public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem>
    {
        Task<int> GetMaxCartId();
        Task<List<ShoppingCartItem>> GetBasketItems(string basketId);
    }
}

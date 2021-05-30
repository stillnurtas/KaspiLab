using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(AWContext context) : base(context) { }
        public AWContext AWContext { get { return _context as AWContext; } }

        public async Task<int> GetMaxCartId()
        {
            var list = await AWContext.ShoppingCartItem
                            .Select(s => s.ShoppingCartID)
                            .Distinct()
                            .ToListAsync();
            return list.Max(m => Convert.ToInt32(m));
        }

        public async Task<List<ShoppingCartItem>> GetBasketItems(string basketId)
        {
            return await AWContext.ShoppingCartItem
                                 .Include(i => i.Product)
                                 .Where(sci => sci.ShoppingCartID == basketId)
                                 .ToListAsync();
        }
    }
}

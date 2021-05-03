using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Context;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AdventureWorks.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AWContext context) : base(context) { }

        public AWContext AWContext { get { return _context as AWContext; } }

        public async Task<IEnumerable<SCProductDTO>> GetShowCaseProducts(int pageIndex = 10, int pageSize = 10)
        {
            return await AWContext.Product
                            .Include(p => p.ProductProductPhoto.Select(ppp => ppp.ProductPhoto.ThumbNailPhoto))
                            .Where(p => p.ProductInventory.Select(pi => pi.Quantity).FirstOrDefault() != 0)
                            .OrderBy(p => p.ProductID)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .Select(p => new SCProductDTO
                            {
                                Name = p.Name,
                                Image = p.ProductProductPhoto.Select(ppp => ppp.ProductPhoto.ThumbNailPhoto).FirstOrDefault()
                            })
                            .ToListAsync();
        }
    }
}

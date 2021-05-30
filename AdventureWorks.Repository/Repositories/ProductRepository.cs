using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
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

        private AWContext AWContext { get { return _context as AWContext; } }

        public async Task<ProductDetailsDTO> GetDetails(int productId)
        {
            return await AWContext.Product
                            .Where(p => p.ProductID == productId)
                            .Include(pi => pi.ProductInventory)
                            .Select(p => new ProductDetailsDTO {
                                Name = p.Name,
                                Price = p.ProductListPriceHistory.Select(plph => plph.ListPrice).FirstOrDefault(),
                                Quantity = p.ProductInventory.Select(pi => pi.Quantity).FirstOrDefault()
                            })
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SCProductDTO>> GetShowCaseProducts(int pageIndex, int pageSize = 24)
        {
            return await AWContext.Product
                            .Where(p => p.ProductInventory.Select(pi => pi.Quantity).FirstOrDefault() != 0)
                            .OrderBy(p => p.ProductID)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .Select(p => new SCProductDTO
                            {
                                Id = p.ProductID,
                                Name = p.Name
                            })
                            .ToListAsync();
        }
    }
}

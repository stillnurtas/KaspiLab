using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Context;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AWContext context) : base(context) { }

        public AWContext AWContext { get { return _context as AWContext; } }

        public IEnumerable<Product> GetShowCaseProducts(int pageIndex, int pageSize = 10)
        {
            return AWContext.Product
                .Include("ProductProductPhoto.ProductPhoto")
                .OrderBy(p => p.ProductID)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}

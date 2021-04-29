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
    public class ProductListPriceHistoryRepository : Repository<ProductListPriceHistory>, IProductListPriceHistoryRepository
    {
        public ProductListPriceHistoryRepository(AWContext context) : base(context) { }
    }
}

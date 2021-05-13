using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class ProductDescriptionRepository : Repository<ProductDescription>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(AWContext context) : base(context) { }
    }
}

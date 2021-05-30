using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(AWContext context) : base(context) { }
        private AWContext AWContext { get { return _context as AWContext; } }

        public async Task<byte[]> GetNailImage(int productId)
        {
            return await AWContext.ProductProductPhoto
                            .Where(ppp => ppp.ProductID == productId)
                            .Select(ppp => ppp.ProductPhoto.ThumbNailPhoto)
                            .FirstOrDefaultAsync();
        }

        public async Task<byte[]> GetLargeImage(int productId)
        {
            return await AWContext.ProductProductPhoto
                            .Where(ppp => ppp.ProductID == productId)
                            .Select(ppp => ppp.ProductPhoto.LargePhoto)
                            .FirstOrDefaultAsync();
        }
    }
}

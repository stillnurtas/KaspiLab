using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Context;
using AdventureWorks.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Services
{
    public class ProductService : IProductService
    {
        public Task<SCProductDTO> GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SCProductDTO>> GetShowCaseProductList()
        {
            using (var db = new AWUnitOfWork(new AWContext()))
            {
                var dbProducts = await db.Product.GetShowCaseProducts(1, 10);
                return dbProducts;
            }
        }

        public async Task<IEnumerable<SCProductDTO>> GetShowCaseProductList(int pageIndex, int pageSize)
        {
            using (var db = new AWUnitOfWork(new AWContext()))
            {
                var dbProducts = await db.Product.GetShowCaseProducts(pageIndex, pageSize);
                return dbProducts;
            }
        }
    }
}

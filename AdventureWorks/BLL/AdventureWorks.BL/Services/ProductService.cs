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
        public async Task<ProductDetailsDTO> GetDetails(int productId)
        {
            using (var uow = new AWUnitOfWork(new AWContext()))
            {
                var details = await uow.Product.GetDetails(productId);
                return details;
            }
        }

        public async Task<byte[]> GetImage(int productId)
        {
            using (var uow = new AWUnitOfWork(new AWContext()))
            {
                var imageData = await uow.Product.GetImage(productId);
                return imageData; 
            }
        }

        public async Task<IEnumerable<SCProductDTO>> GetProducts()
        {
            using (var uow = new AWUnitOfWork(new AWContext()))
            {
                var dbProducts = await uow.Product.GetShowCaseProducts(1, 10);
                return dbProducts;
            }
        }

        public async Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize)
        {
            using (var uow = new AWUnitOfWork(new AWContext()))
            {
                var dbProducts = await uow.Product.GetShowCaseProducts(pageIndex, pageSize);
                return dbProducts;
            }
        }
    }
}

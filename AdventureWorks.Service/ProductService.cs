using AdventureWorks.BL.Infrastructure.Enums;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.BL.Managers;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.IService;
using AdventureWorks.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductManager _productMng;

        public ProductService()
        {
            _productMng = new ProductManager();
        }

        public async Task<ProductDetailsDTO> GetDetails(int productId)
        {
            var details = await _productMng.GetDetails(productId);
            return details;
        }

        public async Task<byte[]> GetImage(int productId, ImageType type)
        {
            var imageData = await _productMng.GetImage(productId, type);
            return imageData;
        }

        public async Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize)
        {
            var dbProducts = await _productMng.GetProducts(pageIndex, pageSize);
            return dbProducts;
        }
    }
}

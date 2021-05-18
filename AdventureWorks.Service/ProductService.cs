using AdventureWorks.DTO.Models.BL;
using AdventureWorks.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service
{
    public class ProductService : IProductService
    {
        public Task<ProductDetailsDTO> GetDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}

using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<SCProductDTO>> GetShowCaseProducts(int pageIndex, int pageSize);
        Task<ProductDetailsDTO> GetDetails(int productId);
    }
}

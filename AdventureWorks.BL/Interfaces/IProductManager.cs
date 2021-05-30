using AdventureWorks.BL.Infrastructure.Enums;
using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IProductManager
    {
        Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize);
        Task<ProductDetailsDTO> GetDetails(int productId);
        Task<byte[]> GetImage(int productId, ImageType type);
    }
}

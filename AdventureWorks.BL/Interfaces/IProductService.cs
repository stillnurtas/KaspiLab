using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<SCProductDTO>> GetShowCaseProductList();
        Task<IEnumerable<SCProductDTO>> GetShowCaseProductList(int pageIndex, int pageSize);
        Task<SCProductDTO> GetProductDetails(int id);
    }
}

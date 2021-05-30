using AdventureWorks.BL.Infrastructure.Enums;
using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.IService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize);

        [OperationContract]
        Task<ProductDetailsDTO> GetDetails(int productId);
        
        [OperationContract]
        Task<byte[]> GetImage(int productId, ImageType type);
    }
}

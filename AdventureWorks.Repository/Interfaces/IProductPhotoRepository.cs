using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Interfaces
{
    public interface IProductPhotoRepository : IRepository<ProductPhoto>
    {
        Task<byte[]> GetNailImage(int productId);
        Task<byte[]> GetLargeImage(int productId);
    }
}

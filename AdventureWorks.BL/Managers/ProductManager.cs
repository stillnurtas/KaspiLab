using AdventureWorks.BL.Infrastructure.Enums;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly AWUnitOfWork _uow;

        public ProductManager()
        {
            _uow = new AWUnitOfWork(new AWContext());
        } 
        public async Task<ProductDetailsDTO> GetDetails(int productId)
        {
            using (_uow)
            {
                var details = await _uow.Product.GetDetails(productId);
                return details;
            }
        }

        public async Task<byte[]> GetImage(int productId, ImageType type)
        {
            using (_uow)
            {
                byte[] imageData = null;
                switch (type)
                {
                    case ImageType.Nail:
                        imageData = await _uow.ProductPhoto.GetNailImage(productId);
                        break;
                    case ImageType.Large:
                        imageData = await _uow.ProductPhoto.GetLargeImage(productId);
                        break;
                }

                return imageData;
            }
        }

        public async Task<IEnumerable<SCProductDTO>> GetProducts(int pageIndex, int pageSize)
        {
            using (_uow)
            {
                var dbProducts = await _uow.Product.GetShowCaseProducts(pageIndex, pageSize);
                return dbProducts;
            }
        }
    }
}

using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Context;
using AdventureWorks.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Core
{
    public class Product : IProduct
    {
        public List<ProductDTO> GetShowCaseProducts(int pageIndex, int pageSize = 10)
        {
            List<ProductDTO> dtoProducts = new List<ProductDTO>();
            using (var db = new AWUnitOfWork(new AWContext()))
            {
                var dbProducts = db.Product.GetShowCaseProducts(pageIndex, pageSize);
                foreach(var product in dbProducts)
                {
                    dtoProducts.Add(new ProductDTO()
                    {
                        Name = product.Name,
                        Image = product.ProductProductPhoto.Select(sp => sp.ProductPhoto.ThumbNailPhoto).FirstOrDefault()
                    });
                }

                return dtoProducts;
            }
        }
    }
}

using AdventureWorks.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using AdventureWorks.Repository.UnitOfWork;
using AdventureWorks.DTO.Models.BL;

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductDTO> res = new List<ProductDTO>();
            using (var db = new AWUnitOfWork(new AWContext()))
            {
                var s = db.Product.GetShowCaseProducts(1, 10);
                foreach(var p in s)
                {
                    res.Add(new ProductDTO()
                    {
                        Name = p.Name,
                        Image = p.ProductProductPhoto.Select(sp => sp.ProductPhoto.ThumbNailPhoto).FirstOrDefault()
                    });
                }
            }
        }
    }
}

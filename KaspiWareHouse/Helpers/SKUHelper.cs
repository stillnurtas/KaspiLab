using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.DTO;

namespace KaspiWareHouse.Helpers
{
    public class SKUHelper
    {
        public static string CreateSKU(Product product)
        {
            return $"{product.Name.ToUpper().Substring(0, 3)}{product.ProductType.ToString().ToUpper().Substring(0, 4)}{product.Price}";
        }
    }
}

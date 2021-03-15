using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.DTO.Products;

namespace KaspiWareHouse.Helpers
{
    public class SKUHelper
    {
        public static string CreateSKU(Product product)
        {
            Console.WriteLine(product.ToString());
            return $"{SubStringName(product.Name)}{product.Price}";
        }

        private static string SubStringName(string name)
        {
            if(name.Length >= 4)
            {
                return name.ToUpper().Substring(0, 4);
            }
            else
            {
                return name.ToUpper();
            }
        }
    }
}

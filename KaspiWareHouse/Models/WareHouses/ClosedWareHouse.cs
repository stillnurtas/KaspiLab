using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.DTO.Products;

namespace KaspiWareHouse.DTO
{
    public class ClosedWareHouse : WareHouseBase
    {
        public ClosedWareHouse()
        {

        }

        public override void AddProduct(ProductBase product, out string message)
        {
            message = String.Empty;
            try
            {
                var sku = SKUHelper.CreateSKU(product);
                if (this.ProductList.Select(p => p.SKU).Contains(sku))
                {
                    this.ProductList.Find(f => f.SKU == sku).Quantity += product.Quantity;
                }
                else
                {
                    this.ProductList.Add(product);
                }
                message = $"{product.Name} added succesfully !";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }
    }
}

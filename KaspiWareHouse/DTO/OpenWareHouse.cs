using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.DTO.Products;

namespace KaspiWareHouse.DTO
{
    public class OpenWareHouse : WareHouse
    {
        public OpenWareHouse()
        {
            
        }

        public override void AddProduct(Product product, out string message)
        {
            message = String.Empty;
            try
            {
                if(product is PieceProduct || product is OverAllProduct)
                {
                    var sku = SKUHelper.CreateSKU(product);
                    if (this.ProductList.Select(p => p.SKU).Contains(sku))
                    {
                        this.ProductList.Find(pl => pl.SKU == sku).Quantity += product.Quantity;
                    }
                    else
                    {
                        this.ProductList.Add(product);
                    }
                    message = $"{product.Name} added succesfully !";
                }
                message = $"You can't add {product.Name} in open WareHouse !";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;

namespace KaspiWareHouse.DTO
{
    public class OpenWareHouse : WareHouse
    {
        public OpenWareHouse(string address, float square) : base(address, square)
        {
            
        }

        public override void AddProduct(Product product, out string message)
        {
            message = String.Empty;
            try
            {
                if(product.ProductType != ProductEnum.Liquid && product.ProductType != ProductEnum.Loose)
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
                message = $"You can't add {product.Quantity} in open WareHouse !";
            }
            catch (Exception e)
            {
                message = e.ToString();
            }
        }
    }
}

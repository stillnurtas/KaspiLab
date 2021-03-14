using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;

namespace KaspiWareHouse.DTO
{
    public class ClosedWareHouse : WareHouse
    {
        public ClosedWareHouse(string address, float square) : base(address, square)
        {

        }

        public override void AddProduct(Product product, out string message)
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
                message = e.ToString();
            }
        }
    }
}

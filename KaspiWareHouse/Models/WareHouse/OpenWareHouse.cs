using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;

namespace KaspiWareHouse.Models.WareHouse
{
    public class OpenWareHouse : BaseWareHouse
    {
        private event Action<BaseWareHouse, WareHouseEventArgs> OnIncorrectProduct;
        public OpenWareHouse()
        {
        }

        public override void AddProduct(BaseProduct product, out string message)
        {
            message = String.Empty;
            try
            {
                if (product is LooseProduct)
                {
                    OnIncorrectProduct?.Invoke(this, new WareHouseEventArgs(product, OnIncorrectProduct.Method.Name));
                    throw new Exception($"You can't add {product.Name} in open WareHouse !");
                }
                var sku = SKUHelper.CreateSKU(product);
                if (this.ProductList.Select(p => p.SKU).Contains(sku))
                {
                    this.ProductList.Find(pl => pl.SKU == sku).Quantity += product.Quantity;
                }
                else
                {
                    this.ProductList.Add(product);
                }
                RaiseEvent(product);
                message = $"{product.Name} added succesfully !";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        public override void SubscribeToEvent()
        {
            OnCorrectProduct += MessageHelper.DisplaySuccessMessage;
            OnIncorrectProduct += MessageHelper.DisplayErrorMessage;
        }
    }
}

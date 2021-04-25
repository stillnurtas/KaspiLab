using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Models.WareHouse;

namespace KaspiWareHouse.Models.WareHouse
{
    public class ClosedWareHouse : BaseWareHouse
    {
        public ClosedWareHouse()
        {

        }

        public override void AddProduct(BaseProduct product)
        {
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
                RaiseEvent(product);
                logger.Debug($"{product.Name} added succesfully !");
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public override void SubscribeToEvent()
        {
            OnCorrectProduct += MessageHelper.DisplaySuccessMessage;
        }
    }
}

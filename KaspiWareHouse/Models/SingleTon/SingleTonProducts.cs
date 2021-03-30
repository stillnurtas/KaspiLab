using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaspiWareHouse.Models.SingleTon
{
    public class SingleTonProducts
    {
        private static SingleTonProducts _instance;
        private Dictionary<string, BaseProduct> Catalog;
        private SingleTonProducts()
        {
            Catalog = new Dictionary<string, BaseProduct>();
        }

        public static SingleTonProducts Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SingleTonProducts();
                }

                return _instance;
            }
        }

        public void AddProduct(BaseProduct product, out string message)
        {
            message = String.Empty;
            try
            {
                var sku = SKUHelper.CreateSKU(product);
                if (Catalog.Select(p => p.Key).Contains(sku))
                {
                    Catalog.Where(c => c.Key == sku).FirstOrDefault().Value.Quantity += product.Quantity;
                }
                else
                {
                    Catalog.Add(sku, product);
                }
                message = $"{product.Name} added succesfully !";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        public BaseProduct GetProduct(string sku, out string message)
        {
            BaseProduct product;
            message = String.Empty;
            try
            {
                Catalog.TryGetValue(sku, out product);
                return product;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }
    }
}

using KaspiWareHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Models.Products
{
    public abstract class BaseProduct
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public Scale MeasurementScale { get; protected set; }

        public BaseProduct(string name, string description, decimal price, float quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            SKU = SKUHelper.CreateSKU(this);
        }
    }
    public enum Scale
    {
        MiliLitr,
        Gramm,
        Kilogramm,
        Ton,
        Litr
    }
}

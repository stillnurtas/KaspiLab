using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.Helpers;

namespace KaspiWareHouse.DTO
{
    public class Product
    {
        public string name;
        public string Name { get { return name; } set { if (value.Trim().Length >= 3) name = value; else name = "Default"; } }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public ProductEnum ProductType { get; set; }

        public Product(string name, string decription, decimal price, float quantity, ProductEnum productType)
        {
            Name = name;
            Description = decription;
            Price = price;
            Quantity = quantity;
            ProductType = productType;
            SKU = SKUHelper.CreateSKU(this);
        }
    }

    public enum ProductEnum
    {
        Loose,
        Liquid,
        Piece,
        Overall
    }
}

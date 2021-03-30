using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.DTO.Products
{
    public abstract class ProductBase
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }

        public ProductBase(string name, string description, decimal price, float quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }
}

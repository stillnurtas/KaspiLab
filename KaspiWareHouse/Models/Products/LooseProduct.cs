using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.Products;

namespace KaspiWareHouse.Models.Products
{
    public class LooseProduct : BaseProduct
    {
        public float MeasurementValue { get; set; }
        public LooseProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
            MeasurementScale = Scale.Gramm;
        }
    }
}

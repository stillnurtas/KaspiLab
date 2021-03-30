using KaspiWareHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Models.Products
{
    public class LiquidProduct : BaseProduct
    {
        public float MeasurementValue { get; set; }
        public LiquidProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
            MeasurementScale = Scale.MiliLitr;
        }
    }
}

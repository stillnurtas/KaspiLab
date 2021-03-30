using KaspiWareHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Models.Products
{
    public class OverAllProduct : BaseProduct
    {
        public int MeasurementValue { get; set; }
        public OverAllProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
            MeasurementScale = Scale.Ton;
        }
    }
}

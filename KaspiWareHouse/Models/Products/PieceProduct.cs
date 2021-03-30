using KaspiWareHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Models.Products
{
    public class PieceProduct : BaseProduct
    {
        public int MeasurementValue { get; set; }
        public PieceProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
            MeasurementScale = Scale.Kilogramm;
        }
    }
}

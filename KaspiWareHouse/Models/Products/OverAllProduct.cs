using KaspiWareHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.DTO.Products
{
    public class OverAllProduct : ProductBase
    {
        public OverAllProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
        }
    }
}

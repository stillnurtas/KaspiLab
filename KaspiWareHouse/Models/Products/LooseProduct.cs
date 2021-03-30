using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.DTO.Products;

namespace KaspiWareHouse.DTO
{
    public class LooseProduct : ProductBase
    {
        public LooseProduct(string name, string description, decimal price, int quantity) : base(name, description, price, quantity)
        {
        }
    }
}

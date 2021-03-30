using System;
using System.Collections.Generic;
using KaspiWareHouse.DTO;
using KaspiWareHouse.DTO.Products;

namespace KaspiWareHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            List<WareHouseBase> wareHouses = new List<WareHouseBase>();
            wareHouses.Add(new OpenWareHouse());
        
            LiquidProduct liquidProduct = new LiquidProduct("Water", "1 ton of water", 500, 5);
            wareHouses[0].AddProduct(liquidProduct, out message);
        }
    }
}

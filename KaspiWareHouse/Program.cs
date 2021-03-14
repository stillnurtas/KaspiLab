using System;
using System.Collections.Generic;
using KaspiWareHouse.DTO;

namespace KaspiWareHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            decimal totalSum = decimal.MinValue;
            List<WareHouse> wareHouse = new List<WareHouse>();
            wareHouse.Add(new OpenWareHouse("ClosedWareHouse", 300f));
            wareHouse.Add(new ClosedWareHouse("OpenWareHouse", 300f));

            wareHouse[0].AddProduct(new Product("Toshiba", "Laptop", 1000, 5, ProductEnum.Piece), out message);
            wareHouse[0].AddProduct(new Product("Acer", "GamingLaptop", 1500, 1, ProductEnum.Piece), out message);
            wareHouse[0].AddProduct(new Product("SONY", "Television", 2000, 7, ProductEnum.Piece), out message);
            wareHouse[0].AddProduct(new Product("SONY", "Television", 1400, 15, ProductEnum.Piece), out message);
            wareHouse[1].AddProduct(new Product("Toshiba", "Laptop", 1000, 5, ProductEnum.Piece), out message);
            wareHouse[1].AddProduct(new Product("Acer", "GamingLaptop", 1500, 3, ProductEnum.Piece), out message);
            wareHouse[1].AddProduct(new Product("SONY", "Television", 2000, 7, ProductEnum.Piece), out message);
            wareHouse[1].AddProduct(new Product("SONY", "Television", 1400, 15, ProductEnum.Piece), out message);

            wareHouse[0].TransferProduct(wareHouse[0].ProductList[0], wareHouse[1], 3, out message);
            //wareHouse[0].SetResponsible(new Employee("Ivan Ivanov", "Loader"), out message);
            Console.WriteLine(message);


            foreach(var wh in wareHouse)
            {
                wh.TotalSum(out totalSum, out message);
                Console.WriteLine($"TotalSum of {wh.Address} is {totalSum}");
            }
        }
    }
}

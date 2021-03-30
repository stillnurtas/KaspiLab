using System;
using System.Collections.Generic;

using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.SingleTon;
using KaspiWareHouse.Models.WareHouse;
using System.IO;
using KaspiWareHouse.Models.Employees;
using KaspiWareHouse.Models.Commands;

namespace KaspiWareHouse
{
    class Program
    {
        static string message;
        static SingleTonProducts SingleTonProducts;
        static void Main(string[] args)
        {
            //CreateSingleTon();
            OpenWareHouse wareHouse = new OpenWareHouse();
            //wareHouse.AddProduct(new LooseProduct("Sand", "1 ton of sand", 500, 1), out message);
            wareHouse.SetResponsible(new Employee("ABC", "Loader"), out message);
            var command = new WareHouseAddCommand(wareHouse, new OverAllProduct("Sand", "1 ton of sand", 500, 1), wareHouse.ResponsibleEmployee);
            var command2 = new WareHouseAddCommand(wareHouse, new OverAllProduct("Sand2", "1 ton of sand", 500, 1), wareHouse.ResponsibleEmployee);
            ExecuteAsync(wareHouse, command, "add");
            ExecuteAsync(wareHouse, command2, "add");
            ExecuteAsync(wareHouse, command2, "exe");
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static async void ExecuteAsync(BaseWareHouse wareHouse, WareHouseAddCommand command, string type)
        {
            if (type.Equals("add"))
            {
                await wareHouse.ResponsibleEmployee.SetCommand(command);
            }
            else
            {
                await wareHouse.ResponsibleEmployee.ExecuteCommand();
            }
        }
        static void CreateSingleTon()
        {
            SingleTonProducts = SingleTonProducts.Instance;
            using (StreamReader reader = new StreamReader(@"C:\Users\Rakhmetullaev_NT\Desktop\KaspiLab-master\KaspiWareHouse\ProductsList.json"))
            {
                string json = reader.ReadToEnd();
                var list = new List<BaseProduct>();
                //DeserializeObject
                foreach(var product in list)
                {
                    SingleTonProducts.AddProduct(product, out message);
                }
            }
        }
    }
}

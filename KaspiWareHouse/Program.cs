using System;
using System.Collections.Generic;
using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Helpers;
using KaspiWareHouse.Models.SingleTon;
using KaspiWareHouse.Models.WareHouse;
using System.IO;
using KaspiWareHouse.Models.Employees;
using KaspiWareHouse.Models.Commands;
using System.Threading;
using KaspiWareHouse.Reflection;

namespace KaspiWareHouse
{
    class Program
    {
        static SingleTonProducts SingleTonProducts;
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static void Main(string[] args)
        {
            ADONet.GetAgreementByIIN("1234567890");
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
                    SingleTonProducts.AddProduct(product);
                }
            }
        }
    }
}

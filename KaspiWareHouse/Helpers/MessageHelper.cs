using KaspiWareHouse.Models.Commands;
using KaspiWareHouse.Models.Employees;
using KaspiWareHouse.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Helpers
{
    public class MessageHelper
    {
        public static void DisplaySuccessMessage(BaseWareHouse sender, WareHouseEventArgs wareHouseEventArgs)
        {
            Console.WriteLine($"{DateTime.Now} | You added {wareHouseEventArgs.Product.Name} into {sender.GetType()} ! Event type: {wareHouseEventArgs.EventType}");
        }
        public static void DisplayErrorMessage(BaseWareHouse sender, WareHouseEventArgs wareHouseEventArgs)
        {
            Console.WriteLine($"{DateTime.Now} | You can't add {wareHouseEventArgs.Product.Name} into {sender.GetType()} ! Event type: {wareHouseEventArgs.EventType}");
        }

        public static void NotifyMessage(Employee sender, AddCommandEventArgs eventArgs)
        {
            Console.WriteLine($"Send notification to {sender.FullName} !");
        }
    }
}

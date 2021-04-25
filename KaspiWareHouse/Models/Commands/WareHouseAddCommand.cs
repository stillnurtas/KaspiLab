using KaspiWareHouse.Helpers;
using KaspiWareHouse.Interfaces;
using KaspiWareHouse.Models.Employees;
using KaspiWareHouse.Models.Products;
using KaspiWareHouse.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Models.Commands
{
    class WareHouseAddCommand : ICommand
    {
        private string message;
        private BaseWareHouse Receiver { get; set; }
        private BaseProduct ProductToAdd { get; set; }
        private Employee EventReceiver { get; set; }

        public event Action<Employee, AddCommandEventArgs> NotifyOnFinish;

        public WareHouseAddCommand(BaseWareHouse receiver, BaseProduct productToAdd, Employee eventReceiver)
        {
            Receiver = receiver;
            ProductToAdd = productToAdd;
            EventReceiver = eventReceiver;
        }
        public void Execute()
        {
            Receiver.AddProduct(ProductToAdd);
            NotifyOnFinish?.Invoke(EventReceiver, new AddCommandEventArgs());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using KaspiWareHouse.Models.Products;

namespace KaspiWareHouse.Models.WareHouse
{
    public class WareHouseEventArgs : EventArgs
    {
        public BaseProduct Product { get; private set; }
        public string EventType { get; private set; }

        public WareHouseEventArgs(BaseProduct product, string eventType)
        {
            Product = product;
            EventType = eventType;
        }
    }
}

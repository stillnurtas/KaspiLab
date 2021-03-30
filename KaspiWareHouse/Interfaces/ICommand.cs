using System;
using System.Collections.Generic;
using System.Text;

using KaspiWareHouse.Models.Employees;
using KaspiWareHouse.Models.Commands;

namespace KaspiWareHouse.Interfaces
{
    public interface ICommand : INotification
    {
        void Execute();
    }
}

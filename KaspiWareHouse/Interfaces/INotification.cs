using KaspiWareHouse.Models.Commands;
using KaspiWareHouse.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiWareHouse.Interfaces
{
    public interface INotification
    {
        event Action<Employee, AddCommandEventArgs> NotifyOnFinish;
    }
}

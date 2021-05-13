using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface ISalesService
    {
        Task SetSalesPerson(OrderDTO order);
        Task ReserveOrderProducts(OrderDTO order);
        Task ExecuteOrder();
    }
}

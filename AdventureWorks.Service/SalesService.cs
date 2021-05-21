using AdventureWorks.DTO.Models.BL;
using AdventureWorks.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service
{
    public class SalesService : ISalesService
    {
        public Task ExecuteOrder()
        {
            throw new NotImplementedException();
        }

        public Task ReserveOrderProducts(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task SetSalesPerson(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}

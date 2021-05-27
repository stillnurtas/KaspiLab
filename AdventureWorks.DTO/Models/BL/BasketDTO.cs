using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DTO.Models.BL
{
    public class BasketDTO
    {
        public Dictionary<string, ShoppingCartItem> Items { get; set; }
    }
}

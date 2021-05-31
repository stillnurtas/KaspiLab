using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DTO.Models.BL
{
    [Serializable]
    public class BasketDTO
    {
        public Dictionary<string, ShoppingCartItem> Items { get; set; } = new Dictionary<string, ShoppingCartItem>();
    }
}

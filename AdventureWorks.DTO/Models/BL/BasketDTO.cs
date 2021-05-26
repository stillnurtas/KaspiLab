using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DTO.Models.BL
{
    public class BasketDTO
    {
        public string BasketId { get; set; }
        public List<SCProductDTO> Items { get; set; }
    }
}

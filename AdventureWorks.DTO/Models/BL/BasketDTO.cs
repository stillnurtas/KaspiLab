using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DTO.Models.BL
{
    [DataContract]
    public class BasketDTO
    {
        [DataMember]
        public decimal BasketPrice { get; set; }
        [DataMember]
        public List<ShoppingCartDTO> Basket { get; set; } = new List<ShoppingCartDTO>();
    }

    [DataContract]
    public class ShoppingCartDTO
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal ProductPrice { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
    }
}

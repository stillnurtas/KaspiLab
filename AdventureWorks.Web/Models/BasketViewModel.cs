using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdventureWorks.Web.Models
{
    public class BasketViewModel
    {
        public int ProductID { get; set; }
        [DisplayName("Name")]
        public string ProductName { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Total")]
        public decimal TotalPrice { get; set; }
    }
}
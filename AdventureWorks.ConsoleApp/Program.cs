using AdventureWorks.DataAccess.Context;
using System;
using System.Linq;

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AWContext())
            {
                var t = context.Products.Select(a => new { Name = a.Name, ProductNumber = a.ProductNumber }).ToList();
            }
        }
    }
}

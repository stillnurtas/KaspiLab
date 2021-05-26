using AdventureWorks.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using AdventureWorks.Repository.UnitOfWork;
using AdventureWorks.DTO.Models.BL;
using System.Data.Entity;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Repositories;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.CustomIdentity;
using AdventureWorks.Auth.IdentityManagers;
using Microsoft.AspNet.Identity;
using AdventureWorks.ConsoleApp.ProductService;
using AdventureWorks.ConsoleApp.ServiceReference1;

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        public static AWContext AWContext { get; private set; }

        static void Main(string[] args)
        {
            Test().GetAwaiter().GetResult();
        }

        static async Task Test()
        {
            using (AWUnitOfWork uow = new AWUnitOfWork(new AWContext()))
            {

                uow.ShoppingCartItem.Create(new ShoppingCartItem
                {
                    ShoppingCartID = "51451",
                    Quantity = 1,
                    ProductID = 2,
                    DateCreated = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });

                var t = await uow.Save();
            }
        }
    }
}
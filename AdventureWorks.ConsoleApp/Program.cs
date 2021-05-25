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

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductServiceClient client = new ProductServiceClient())
            {
                var t = client.GetProducts(1, 24);
            }
        }

        static async Task Test()
        {
            using (AWUnitOfWork uow = new AWUnitOfWork(new AWContext()))
            {
                var r = await uow.Product.GetShowCaseProducts(1,24);
            }
        }
    }
}
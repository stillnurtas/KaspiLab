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

namespace AdventureWorks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().GetAwaiter().GetResult();
        }

        static async Task Test()
        {
            var mng = new AppUserManager(new AppUserStore(new AWContext()));
            var user = new AppUser { UserName = "nurtas@gmail.com", Email = "nurtas@gmail.com" };
            var result = await mng.CreateAsync(user);
            try
            {
                using (var db = new AWUnitOfWork(new AWContext()))
                {
                    var t = db.AppUserManager.CreateAsync(new AppUser { UserName = "nuras@gmail.com", Email = "nurtas@gmail.com" });
                    
                }
                //var mng = new AppUserManager(new AppUserStore(new AWContext()));
                //var role = new AppRoleManager(new AppRoleStore(new AWContext()));
                //var user = new AppUser { UserName = "nurtas@gmail.com", Email = "nurtas@gmail.com" };
                //var result = await mng.CreateAsync(user);
                //var res = await mng.AddToRoleAsync(1, "user");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
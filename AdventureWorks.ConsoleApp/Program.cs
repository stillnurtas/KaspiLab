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
using AdventureWorks.BL.Services;

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
            try
            {
                AuthService service = new AuthService();
                var t = new UserDTO { Email = "nurtas2@mail.ru", UserName = "nurtas2@mail.ru", Password = "123456", Role = "admin" };
                var res = await service.Register(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
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
            var _uow = new AWUnitOfWork(new AWContext());
            var address = new Address
            {
                AddressLine1 = "asda",
                City = "Astana",
                StateProvinceID = 11,
                PostalCode = "000155",
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };
            _uow.Address.Create(address);
            await _uow.Save();
        }
    }
}
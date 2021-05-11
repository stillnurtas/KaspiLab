using AdventureWorks.EF.Models;
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.EF.Context
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext() : base("name=AdventureWorks") { }
    }
}

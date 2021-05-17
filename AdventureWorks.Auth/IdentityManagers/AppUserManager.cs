using AdventureWorks.Auth.Intefaces;
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Auth.Identity
{
    public class AppUserManager : UserManager<AppUser, int>
    {
        public AppUserManager(IAppUserStore store) : base(store) { }
    }
}

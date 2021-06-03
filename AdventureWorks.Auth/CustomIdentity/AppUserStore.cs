using AdventureWorks.Auth.Intefaces;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Auth.CustomIdentity
{
    public class AppUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>, IAppUserStore
    {
        public AppUserStore() : base(new AWContext_old()) { }

        public AppUserStore(AWContext_old context) : base(context) { }
    }
}

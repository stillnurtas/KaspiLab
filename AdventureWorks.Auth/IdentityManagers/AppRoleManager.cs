using AdventureWorks.Auth.Intefaces;
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Auth.IdentityManagers
{
    public class AppRoleManager : RoleManager<AppRole, int>
    {
        public AppRoleManager(IAppRoleStore store) : base(store) { }
    }
}

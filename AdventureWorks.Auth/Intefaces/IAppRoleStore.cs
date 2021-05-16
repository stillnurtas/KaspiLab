
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Auth.Intefaces
{
    public interface IAppRoleStore : IRoleStore<AppRole, int>
    {
    }
}

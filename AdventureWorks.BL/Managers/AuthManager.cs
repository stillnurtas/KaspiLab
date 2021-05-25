using AdventureWorks.Auth.CustomIdentity;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.IdentityManagers;
using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.UnitOfWork;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly AppUserManager _userMng;
        private readonly AppRoleManager _roleMng;

        public AuthManager()
        {
            _userMng = new AppUserManager(new AppUserStore(new AWContext()));
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            AppUser user = await _userMng.FindAsync(userDto.Email, userDto.Password);
            ClaimsIdentity claim = user != null ? await _userMng.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie) : null;
            _userMng.Dispose();
            return claim;
        }

        public async Task<OperationDetails> Register(UserDTO userDto)
        {
            try
            {
                AppUser user = await _userMng.FindByEmailAsync(userDto.Email);
                if (user == null)
                {
                    user = new AppUser { UserName = userDto.Email, Email = userDto.Email };
                    var result = await _userMng.CreateAsync(user, userDto.Password);
                    if (result.Errors.Count() > 0)
                        return new OperationDetails(OperationDetails.Statuses.Error, result.Errors.FirstOrDefault(), "");

                    await _userMng.AddToRoleAsync(user.Id, userDto.Role);
                    _userMng.Dispose();

                    return new OperationDetails(OperationDetails.Statuses.Success, "Registration was successful!", "");
                }
                else
                {
                    return new OperationDetails(OperationDetails.Statuses.Error, "User with this login exists", "Email");
                }
            }
            catch (Exception e)
            {
                return new OperationDetails(OperationDetails.Statuses.Error, $"{e.Message}", "Exception");
            }
        }
    }
}

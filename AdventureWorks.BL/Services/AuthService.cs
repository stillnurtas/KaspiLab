using AdventureWorks.Auth.Identity;
using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityContext _context;
        private readonly AppRoleManager _roleManager;
        private readonly AppUserManager _userManager;

        public AuthService()
        {
            _context = new IdentityContext();
            _roleManager = new AppRoleManager(new RoleStore<AppRole>(_context));
            _userManager = new AppUserManager(new UserStore<AppUser>(_context));
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            AppUser user = await _userManager.FindAsync(userDto.Email, userDto.Password);
            ClaimsIdentity claim = user != null ? await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie) : null;
            return claim;
        }

        public async Task<OperationDetails> Register(UserDTO userDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                return new OperationDetails(OperationDetails.Statuses.Success, "Registration was successful!", "");
            }
            else
            {
                return new OperationDetails(OperationDetails.Statuses.Error, "User with this login exists", "Email");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

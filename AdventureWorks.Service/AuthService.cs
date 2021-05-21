using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.BL.Infrastructure;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.IService;
using AdventureWorks.Repository.UnitOfWork;
using Microsoft.AspNet.Identity;

namespace AdventureWorks.Service
{
    public class AuthService : IAuthService
    {
        private readonly AWUnitOfWork _uow;

        public AuthService()
        {
            _uow = new AWUnitOfWork(new AWContext());
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            AppUser user = await _uow.AppUserManager.FindAsync(userDto.Email, userDto.Password);
            ClaimsIdentity claim = user != null ? await _uow.AppUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie) : null;
            return claim;
        }

        public async Task<OperationDetails> Register(UserDTO userDto)
        {
            try
            {
                AppUser user = await _uow.AppUserManager.FindByEmailAsync(userDto.Email);
                if (user == null)
                {
                    user = new AppUser { UserName = userDto.Email, Email = userDto.Email };
                    var result = await _uow.AppUserManager.CreateAsync(user, userDto.Password);
                    if (result.Errors.Count() > 0)
                        return new OperationDetails(OperationDetails.Statuses.Error, result.Errors.FirstOrDefault(), "");

                    await _uow.AppUserManager.AddToRoleAsync(user.Id, userDto.Role);
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

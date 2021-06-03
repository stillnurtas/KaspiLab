using AdventureWorks.Auth.CustomIdentity;
using AdventureWorks.Auth.Identity;
using AdventureWorks.Auth.IdentityManagers;
using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
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
        private readonly AWUnitOfWork _uow;

        public AuthManager()
        {
            _userMng = new AppUserManager(new AppUserStore(new AWContext_old()));
            _uow = new AWUnitOfWork(new AWContext());
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            AppUser user = await _userMng.FindAsync(userDto.Email, userDto.Password);
            ClaimsIdentity claim = user != null ? await _userMng.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie) : null;
            _userMng.Dispose();
            return claim;
        }

        public async Task<OperationDetails> Register(RegisDTO userDto)
        {
            try
            {
                AppUser user = await _userMng.FindByEmailAsync(userDto.Email);
                if (user == null)
                {
                    var entityId = CreateClient(userDto);
                    user = new AppUser { UserName = userDto.Email, Email = userDto.Email, BusinessEntityID = entityId };
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

        private int CreateClient(RegisDTO registerDto)
        {
            using (_uow)
            {
                var entityID = new BusinessEntity();
                var person = new Person { BusinessEntityID = entityID.BusinessEntityID, PersonType = "GC", FirstName = registerDto.FirstName, LastName = registerDto.LastName };
                var address = new Address { AddressLine1 = registerDto.Address, City = registerDto.City, StateProvinceID = registerDto.StateProvinceID, PostalCode = registerDto.PostalCode };
                _uow.BusinessEntity.Create(entityID);
                _uow.Person.Create(person);
                _uow.Address.Create(address);
                _uow.Customer.Create(new Customer { PersonID = person.BusinessEntityID, TerritoryID = registerDto.StateProvinceID });
                _uow.BusinessEntityAddress.Create(new BusinessEntityAddress
                {
                    BusinessEntityID = entityID.BusinessEntityID,
                    AddressTypeID = 2,
                    AddressID = address.AddressID
                });

                return entityID.BusinessEntityID;
            }
        }

        public async Task<RegisInfoDTO> GetRegisInfo()
        {
            using(_uow)
            {
                RegisInfoDTO regisInfo = new RegisInfoDTO();
                var states = await _uow.StateProvince.GetAll();
                states.ToList().ForEach(s => { regisInfo.Provinces.Add(new Province { Id = s.StateProvinceID, Name = s.Name }); });
                return regisInfo;
            }
        }
    }
}

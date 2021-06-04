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
using System.Data.Entity;
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
        private readonly IUnitOfWork _uow;

        public AuthManager()
        {
            _userMng = new AppUserManager(new AppUserStore(new AWContext()));
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
                    var entityId = await CreateClient(userDto);
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

        private async Task<int> CreateClient(RegisDTO registerDto)
        {
            using (DbContextTransaction transaction = _uow.Context.Database.BeginTransaction())
            {
                try
                {
                    var bEntity = new BusinessEntity() { ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid() };
                    _uow.BusinessEntity.Create(bEntity);
                    await _uow.Save();
                    var person = new Person { BusinessEntityID = bEntity.BusinessEntityID, 
                                              PersonType = "GC", 
                                              FirstName = registerDto.FirstName, 
                                              LastName = registerDto.LastName,
                                              rowguid = Guid.NewGuid(),
                                              ModifiedDate = DateTime.Now };
                    _uow.Person.Create(person);
                    await _uow.Save();
                    var address = new Address { AddressLine1 = registerDto.Address, 
                                                City = registerDto.City, 
                                                StateProvinceID = registerDto.StateProvinceID, 
                                                PostalCode = registerDto.PostalCode,
                                                rowguid = Guid.NewGuid(),
                                                ModifiedDate = DateTime.Now };
                    _uow.Address.Create(address);
                    await _uow.Save();

                    var bEntityAddress = new BusinessEntityAddress
                    {
                        BusinessEntityID = bEntity.BusinessEntityID,
                        AddressTypeID = 2,
                        AddressID = address.AddressID,
                        ModifiedDate = DateTime.Now,
                        rowguid = Guid.NewGuid()
                    };
                    _uow.BusinessEntityAddress.Create(bEntityAddress);
                    await _uow.Save();
                    _uow.Customer.Create(new Customer { PersonID = person.BusinessEntityID, 
                                                        TerritoryID = registerDto.StateProvinceID,
                                                        rowguid = Guid.NewGuid(),
                                                        ModifiedDate = DateTime.Now});;
                    await _uow.Save();
                    transaction.Commit();

                    return bEntity.BusinessEntityID;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<RegisInfoDTO> GetRegisInfo()
        {
            using (_uow)
            {
                RegisInfoDTO regisInfo = new RegisInfoDTO();
                var states = await _uow.StateProvince.GetAll();
                states.ToList().ForEach(s => { regisInfo.Provinces.Add(new Province { Id = s.StateProvinceID, Name = s.Name }); });
                return regisInfo;
            }
        }
    }
}

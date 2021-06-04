using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.BL.Infrastructure;
using AdventureWorks.BL.Interfaces;
using AdventureWorks.BL.Managers;
using AdventureWorks.DTO.Models.BL;
using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models.IdentityModels;
using AdventureWorks.IService;
using AdventureWorks.Repository.Interfaces;
using AdventureWorks.Repository.UnitOfWork;
using Microsoft.AspNet.Identity;

namespace AdventureWorks.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthManager _authMng;

        public AuthService()
        {
            _authMng = new AuthManager();
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            var claim = await _authMng.Authenticate(userDto);
            return claim;
        }

        public async Task<RegisInfoDTO> GetRegisInfo()
        {
            var info = await _authMng.GetRegisInfo();
            return info;
        }

        public async Task<OperationDetails> Register(RegisDTO userDto)
        {
            var opDetail = await _authMng.Register(userDto);
            return opDetail;
        }
    }
}

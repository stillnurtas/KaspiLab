using AdventureWorks.BL.Infrastructure;
using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Interfaces
{
    public interface IAuthManager
    {
        Task<OperationDetails> Register(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
    }
}

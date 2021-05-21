using AdventureWorks.BL.Infrastructure;
using AdventureWorks.DTO.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.IService
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        Task<OperationDetails> Register(UserDTO userDto);

        [OperationContract]
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
    }
}

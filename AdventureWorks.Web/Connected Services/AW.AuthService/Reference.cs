﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdventureWorks.Web.AW.AuthService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AW.AuthService.IAuthService")]
    public interface IAuthService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/Register", ReplyAction="http://tempuri.org/IAuthService/RegisterResponse")]
        AdventureWorks.BL.Infrastructure.OperationDetails Register(AdventureWorks.DTO.Models.BL.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/Register", ReplyAction="http://tempuri.org/IAuthService/RegisterResponse")]
        System.Threading.Tasks.Task<AdventureWorks.BL.Infrastructure.OperationDetails> RegisterAsync(AdventureWorks.DTO.Models.BL.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/Authenticate", ReplyAction="http://tempuri.org/IAuthService/AuthenticateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AdventureWorks.DTO.Models.BL.UserDTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AdventureWorks.BL.Infrastructure.OperationDetails))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AdventureWorks.BL.Infrastructure.OperationDetails.Statuses))]
        System.Security.Claims.ClaimsIdentity Authenticate(AdventureWorks.DTO.Models.BL.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/Authenticate", ReplyAction="http://tempuri.org/IAuthService/AuthenticateResponse")]
        System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> AuthenticateAsync(AdventureWorks.DTO.Models.BL.UserDTO userDto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthServiceChannel : AdventureWorks.Web.AW.AuthService.IAuthService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthServiceClient : System.ServiceModel.ClientBase<AdventureWorks.Web.AW.AuthService.IAuthService>, AdventureWorks.Web.AW.AuthService.IAuthService {
        
        public AuthServiceClient() {
        }
        
        public AuthServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AdventureWorks.BL.Infrastructure.OperationDetails Register(AdventureWorks.DTO.Models.BL.UserDTO userDto) {
            return base.Channel.Register(userDto);
        }
        
        public System.Threading.Tasks.Task<AdventureWorks.BL.Infrastructure.OperationDetails> RegisterAsync(AdventureWorks.DTO.Models.BL.UserDTO userDto) {
            return base.Channel.RegisterAsync(userDto);
        }
        
        public System.Security.Claims.ClaimsIdentity Authenticate(AdventureWorks.DTO.Models.BL.UserDTO userDto) {
            return base.Channel.Authenticate(userDto);
        }
        
        public System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> AuthenticateAsync(AdventureWorks.DTO.Models.BL.UserDTO userDto) {
            return base.Channel.AuthenticateAsync(userDto);
        }
    }
}
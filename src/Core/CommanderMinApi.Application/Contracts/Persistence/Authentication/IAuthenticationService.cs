using CommanderMinApi.Application.RequestModels.Authentication;
using CommanderMinApi.Application.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<string>> Authenticate(AuthenticationRequest authRequest);
        Task<ServiceResponse<Guid>> Register(RegistrationRequest authRequest);
        Task<ServiceResponse<Guid>> ChangePassword(ChangePasswordRequest changePasswordRequest);
    }
}

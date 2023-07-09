using CommanderMinApi.Application.RequestModels.Authentication;
using CommanderMinApi.Application.ServiceResponses;

namespace CommanderMinApi.Application.Contracts.Persistence.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<string>> Authenticate(AuthenticationRequest authRequest);
        Task<ServiceResponse<Guid>> Register(RegistrationRequest authRequest);
        Task<ServiceResponse<Guid>> ChangePassword(ChangePasswordRequest changePasswordRequest);
    }
}
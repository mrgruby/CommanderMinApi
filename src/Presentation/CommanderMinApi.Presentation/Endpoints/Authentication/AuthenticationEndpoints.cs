using Carter;
using CommanderMinApi.Application.Contracts.Persistence.Authentication;
using CommanderMinApi.Application.RequestModels.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Presentation.Endpoints.Authentication
{
    public class AuthenticationEndpoints : CarterModule
    {
        public AuthenticationEndpoints() : base("api/authentication")
        {
            
        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/authenticate", async (IAuthenticationService authService, AuthenticationRequest request) =>
            {
                var result = await authService.Authenticate(request);

                if (result != null && result.Success == false)
                {
                    return Results.BadRequest(result.Message);
                }
                return Results.Ok(result);
            });

            app.MapPost("/register", async (IAuthenticationService authService, RegistrationRequest request) =>
            {
                var response = await authService.Register(request);

                if (!response.Success)
                {
                    return Results.BadRequest(response.Message);
                }
                return Results.Ok(response);
            });

            app.MapPut("/update-user", async (IAuthenticationService authService, ChangePasswordRequest request) =>
            {
                var response = await authService.ChangePassword(request);

                if (!response.Success)
                {
                    return Results.BadRequest(response.Message);
                }
                return Results.Ok(response);
            });
        }
    }
}

using Carter;
using CommanderMinApi.Application.Contracts.Persistence.Authentication;
using CommanderMinApi.Application.RequestModels.Authentication;
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
            app.MapPost("/", async (IAuthenticationService authService, AuthenticationRequest request) =>
            {

            });
        }
    }
}

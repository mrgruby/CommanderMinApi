using Carter;
using CommanderMinApi.Application.Features.Queries.CommandLine;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Presentation.Endpoints.CommandLines
{
    /// <summary>
    /// This class inherits the ICarterModule. Every class that uses this interface, will automatically be registered at 
    /// startup. app.MapCarter() in program.cs
    /// </summary>
    public class CommandLineEndpoints : CarterModule
    {
        public CommandLineEndpoints() : base ("/api/commandlines/{platformId}/commands")
        {
            
        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (IMediator mediator, Guid platformId) =>
            {
                var query = new GetCommandLineListByPlatformQuery { PlatformId = platformId };

                var getCommandLineListByPlatformReturnModel = await mediator.Send(query);

                if (getCommandLineListByPlatformReturnModel.Data == null)
                {
                    return Results.BadRequest();
                }

                return Results.Ok(getCommandLineListByPlatformReturnModel);
            });
        }
    }
}

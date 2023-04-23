using Carter;
using CommanderMinApi.Application.Features.Commands.CommandLines;
using CommanderMinApi.Application.Features.Queries.CommandLine.GetComandLineListByPlatform;
using CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineByPlatform;
using CommanderMinApi.Application.RequestModels.CommandLines;
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
        //This creates a base route for all endpoins, like the Route attribute in regular controllers.
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

            app.MapGet("/{commandLineId}", async (IMediator mediator, Guid platformId, Guid commandLineId) =>
            {
                var query = new GetCommandLineByPlatformQuery { PlatformId = platformId, CommandLineId = commandLineId };

                var getCommandLineByPlatformReturnModel = await mediator.Send(query);

                if (getCommandLineByPlatformReturnModel.Data == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(getCommandLineByPlatformReturnModel);
            }).WithName("getCommandLineByPlatform");

            app.MapPost("/", async (IMediator mediator, CreateCommandLineRequestModel commandLineToAdd, Guid platformId) =>
            {
                var command = new CreateCommandLineCommand(platformId, commandLineToAdd);
                var returnModel = await mediator.Send(command);

                if (returnModel.Success)
                    //Return the newly created ressource, along with a link to it.
                    return Results.CreatedAtRoute("getCommandLineByPlatform", new { platformId = platformId, commandLineId = returnModel.Data.CommandLineId }, returnModel);
                else
                    return Results.BadRequest($"Failed to save new CommandLine - {string.Join(", ", returnModel.ValidationErrors)}");
            });
        }
    }
}

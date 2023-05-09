using Carter;
using CommanderMinApi.Application.Features.Commands.CommandLines.CreateCommandLine;
using CommanderMinApi.Application.Features.Commands.CommandLines.DeleteCommandLine;
using CommanderMinApi.Application.Features.Commands.CommandLines.UpdateCommandLine;
using CommanderMinApi.Application.Features.Queries.CommandLine.GetComandLineListByPlatform;
using CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineByPlatform;
using CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineSearchSuggestions;
using CommanderMinApi.Application.RequestModels.CommandLines;
using CommanderMinApi.Domain.Entities;
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
        public CommandLineEndpoints() : base ("/api/platform/{platformId}/commands")
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

            //Get CommandLines by search text.
            app.MapGet("/{page}/{searchText}", async (IMediator mediator, string searchText, int page) =>
            {
                var query = new GetCommandLineSearchQuery { CurrentPage = page, SearchText = searchText };

                var getCommandLineListBysearchTextReturnModel = await mediator.Send(query);

                if (getCommandLineListBysearchTextReturnModel.Data == null)
                {
                    return Results.BadRequest();
                }

                return Results.Ok(getCommandLineListBysearchTextReturnModel);
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
                    return Results.CreatedAtRoute("getCommandLineByPlatform", new { platformId, commandLineId = returnModel.Data.CommandLineId }, returnModel);
                else
                    return Results.BadRequest($"Failed to save new CommandLine - {string.Join(", ", returnModel.ValidationErrors)}");
            });

            app.MapPut("/{commandLineId}", async (IMediator mediator, Guid platformId, Guid commandLineId, UpdateCommandLineRequestModel commandLineUpdateModel) =>
            {
                var command = new UpdateCommandLineCommand(platformId, commandLineId, commandLineUpdateModel);
                var response = await mediator.Send(command);

                if (response.Success == false && response.Message == "Notfound")
                    return Results.NotFound($"CommandLine to update, with Id {commandLineId}, was not found!");
                if (response.Success == false && response.ValidationErrors.Count > 0)
                    return Results.BadRequest($"Failed to update CommandLine - {string.Join(", ", response.ValidationErrors)}");

                return Results.NoContent();
            });

            app.MapDelete("/{commandLineId}", async (IMediator mediator, Guid platformId, Guid commandLineId) =>
            {
                var command = new DeleteCommandLineCommand(commandLineId, platformId);
                var response = await mediator.Send(command);

                if (!response.Success)
                {
                    return Results.NotFound(response.Message);
                }

                return Results.NoContent();
            });
        }
    }
}

using Carter;
using CommanderMinApi.Application.Features.Commands.Platforms.CreatePlatform;
using CommanderMinApi.Application.Features.Commands.Platforms.DeletePlatform;
using CommanderMinApi.Application.Features.Commands.Platforms.UpdatePlatform;
using CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformByIdWithCommandLines;
using CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformsList;
using CommanderMinApi.Application.RequestModels.Platforms;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Presentation.Endpoints.Platforms
{
    public class PlatformEndpoints : CarterModule
    {
        public PlatformEndpoints() : base("api/platform")
        {

        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetPlatformsListQuery();
                var platformsResult = await mediator.Send(query);
                if (platformsResult.Data == null & !platformsResult.Success)
                {
                    return Results.BadRequest(platformsResult.Message);
                }
                return Results.Ok(platformsResult);
            });

            app.MapGet("/{platformId}", async (IMediator mediator, Guid platformId) =>
            {
                var query = new GetPlatformByIdQuery(platformId);//Uses a record instead of a class
                var platformResult = await mediator.Send(query);
                if (platformResult.Data == null & !platformResult.Success)
                {
                    return Results.BadRequest(platformResult.Message);
                }
                return Results.Ok(platformResult);
            })
                .WithName("GetPlatformById");

            //Create
            app.MapPost("/", async (IMediator mediator, CreatePlatformRequestModel createPlatformRequestModel) =>
            {
                var command = new CreatePlatformCommand(createPlatformRequestModel);

                var response = await mediator.Send(command);

                if (response.Success)
                    return Results.CreatedAtRoute("GetPlatformById", new { response.Data.PlatformId, response });
                else
                    return Results.BadRequest($"One or more errors occurred while saving the platform - {string.Join(", ", response.ValidationErrors)}");
            });

            //Update
            app.MapPut("/{platformId}", async (IMediator mediator, Guid platformId, UpdatePlatformRequestModel updatePlatformRequestModel) =>
            {
                var command = new UpdatePlatformCommand(platformId, updatePlatformRequestModel);
                var response = await mediator.Send(command);

                if (response.Success == false && response.Message == "Notfound")
                    return Results.NotFound($"Platform to update, with Id {platformId}, was not found!");
                if (response.Success == false && response.ValidationErrors.Count > 0)
                    return Results.BadRequest($"Failed to update Platform - {string.Join(", ", response.ValidationErrors)}");

                return Results.NoContent();
            });

            //Delete
            app.MapDelete("/{platformId}", async (IMediator mediator, Guid platformId) =>
            {
                var response = await mediator.Send(new DeletePlatformCommand(platformId));
                if (!response.Success)
                    return Results.NotFound(response.Message);

                return Results.NoContent();
            });

            app.MapPost("/upload-image", async (IMediator mediator, IFormFile file) =>
            {
                
            });
        }


    }
}

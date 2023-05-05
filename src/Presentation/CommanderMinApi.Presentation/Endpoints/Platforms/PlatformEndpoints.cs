using Carter;
using CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformByIdWithCommandLines;
using CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformsList;
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
        public PlatformEndpoints() :base("api/platforms")
        {
            
        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetPlatformsListQuery();
                var platformsResult = await mediator.Send(query);
                if (platformsResult.Data == null &! platformsResult.Success)
                {
                    return Results.BadRequest(platformsResult.Message);
                }
                return Results.Ok(platformsResult);
            });

            app.MapGet("/{platformId}", async (IMediator mediator, Guid platformId) =>
            {
                var query = new GetPlatformByIdQuery(platformId);//Uses a record instead of a class
                var platformResult = await mediator.Send(query);
                if(platformResult.Data == null &! platformResult.Success)
                {
                    return Results.BadRequest(platformResult.Message);
                }
                return Results.Ok(platformResult);
            });

            //Create


            //Update


            //Delete
        }

        
    }
}

using CommanderMinApi.Application.RequestModels.Platforms;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.Platforms.CreatePlatform
{
    public record CreatePlatformCommand(CreatePlatformRequestModel platformRequestModel) : IRequest<ServiceResponse<PlatformResponseDTO>>
    {
    }
}

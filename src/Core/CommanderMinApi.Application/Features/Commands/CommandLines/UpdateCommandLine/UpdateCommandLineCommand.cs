using CommanderMinApi.Application.RequestModels.CommandLines;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.CommandLines.UpdateCommandLine
{
    public record UpdateCommandLineCommand(Guid platformId,Guid commandLineId, UpdateCommandLineRequestModel commandLineUpdateModel) : IRequest<ServiceResponse<CommandLineResponseDTO>>
    {
    }
}

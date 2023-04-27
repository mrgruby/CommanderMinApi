using CommanderMinApi.Application.RequestModels.CommandLines;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.CommandLines.CreateCommandLine
{
    public record CreateCommandLineCommand(Guid platformId, CreateCommandLineRequestModel commandLine) : IRequest<ServiceResponse<CommandLineResponseDTO>>;
}

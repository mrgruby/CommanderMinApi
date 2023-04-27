using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.CommandLines.DeleteCommandLine
{
    public record DeleteCommandLineCommand(Guid commandLineId, Guid platformId) : IRequest<ServiceResponse<bool>>
    {
    }
}

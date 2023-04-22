using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Queries.CommandLine
{
    public class GetCommandLineListByPlatformQuery : IRequest<ServiceResponse<List<CommandLineResponseDTO>>>
    {
        public Guid PlatformId { get; set; }
    }
}
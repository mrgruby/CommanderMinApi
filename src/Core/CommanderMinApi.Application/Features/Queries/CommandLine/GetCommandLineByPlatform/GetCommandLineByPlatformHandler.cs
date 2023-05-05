using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using Mapster;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineByPlatform
{
    public class GetCommandLineByPlatformHandler : IRequestHandler<GetCommandLineByPlatformQuery, ServiceResponse<CommandLineResponseDTO>>
    {
        private readonly ICommandLineRepository _repo;

        public GetCommandLineByPlatformHandler(ICommandLineRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse<CommandLineResponseDTO>> Handle(GetCommandLineByPlatformQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<CommandLineResponseDTO>();

            var commandLineFromDb = await _repo.GetCommandLineByPlatform(request.PlatformId, request.CommandLineId);

            if (commandLineFromDb == null )
            {
                response.Success = false;
                response.Message = "Un-able to retrieve commandline";
                return response;
            }
            response.Data = commandLineFromDb.Adapt<CommandLineResponseDTO>();

            return response;
        }
    }
}

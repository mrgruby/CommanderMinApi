using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Queries.CommandLine.GetComandLineListByPlatform
{
    public class GetCommandLineListByPlatformHandler : IRequestHandler<GetCommandLineListByPlatformQuery, ServiceResponse<List<CommandLineResponseDTO>>>
    {
        private readonly ICommandLineRepository _repo;

        public GetCommandLineListByPlatformHandler(ICommandLineRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse<List<CommandLineResponseDTO>>> Handle(GetCommandLineListByPlatformQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<List<CommandLineResponseDTO>>();

            var commandLineListFromDb = await _repo.GetCommandLineListByPlatform(request.PlatformId);

            if (commandLineListFromDb == null)
            {
                response.Success = false;
                response.Message = "Un-able to retrieve a list of CommandLines.";
                return response;
                //throw new NotFoundException(nameof(GetCommandLineListByPlatformReturnModel), request.PlatformId);
            }
            response.Data = commandLineListFromDb.Adapt<List<CommandLineResponseDTO>>();

            return response;
        }
    }
}

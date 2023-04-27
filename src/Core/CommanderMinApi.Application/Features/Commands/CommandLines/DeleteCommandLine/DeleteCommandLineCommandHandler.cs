using CommanderMinApi.Application.Contracts.Persistence;
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
    public class DeleteCommandLineCommandHandler : IRequestHandler<DeleteCommandLineCommand, ServiceResponse<bool>>
    {
        private readonly ICommandLineRepository _repo;

        public DeleteCommandLineCommandHandler(ICommandLineRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteCommandLineCommand request, CancellationToken cancellationToken)
        {
            var commandLineToDelete = await _repo.GetCommandLineByPlatform(request.platformId, request.commandLineId);
            var response = new ServiceResponse<bool>();

            if (commandLineToDelete == null)
            {
                response.Success = false;
                response.Message = "Commandline to delete was not found";
                return response;
            }

            response.Data = true;
            return response;
        }
    }
}

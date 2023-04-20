using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Application.Validators;
using CommanderMinApi.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.CommandLines
{
    public class CreateCommandLineCommandHandler : IRequestHandler<CreateCommandLineCommand, ServiceResponse<CommandLineResponseDTO>>
    {
        private readonly ICommandLineRepository _repo;

        public CreateCommandLineCommandHandler(ICommandLineRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<CommandLineResponseDTO>> Handle(CreateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<CommandLineResponseDTO>();
            var validator = new CreateCommandLineValidator();

            var validationResult = await validator.ValidateAsync(request.commandLine);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                //Map from the CommandLine request model to a CommandLine Entity, in order to add it to the database.
                var commandLine = request.commandLine.Adapt<CommandLine>();

                //Add to database. SaveChanges is called in the Add method.
                _repo.Add(commandLine, request.platformId);

                //Map from the CommandLine Entity to a CreateCommandLineDto, which is added to the response return model.
                response.Data = commandLine.Adapt<CommandLineResponseDTO>();
            }

            return response;
        }
    }
}

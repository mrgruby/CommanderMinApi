using AutoMapper;
using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Application.Validators.CommandLines;
using CommanderMinApi.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.CommandLines.UpdateCommandLine
{
    public class UpdateCommandLineCommandHandler : IRequestHandler<UpdateCommandLineCommand, ServiceResponse<CommandLineResponseDTO>>
    {
        private readonly ICommandLineRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCommandLineCommandHandler(ICommandLineRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CommandLineResponseDTO>> Handle(UpdateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<CommandLineResponseDTO>();
            var validator = new UpdateCommandLineValidator();

            //Get the command we want to update from the database. Use the id's from the request.
            var commandLineFromDbToUpdate = await _repo.GetCommandLineByPlatform(request.platformId, request.commandLineId);

            //If the command does not exist, return a failed response.
            if (commandLineFromDbToUpdate == null)
            {
                response.Success = false;
                response.Message = "Notfound";
                return response;
            }

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken.
            //If so, add the error message to the ValidationErrors list in the validationResult.
            var validationResult = await validator.ValidateAsync(request.commandLineUpdateModel);

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
                //This mapping changes the entity into a modified state, and this is tracked by the context,
                //so the actual update happens when calling Save on the context.
                _mapper.Map(request.commandLineUpdateModel, commandLineFromDbToUpdate);
                _repo.Update(commandLineFromDbToUpdate);
            }
            return response;
        }
    }
}

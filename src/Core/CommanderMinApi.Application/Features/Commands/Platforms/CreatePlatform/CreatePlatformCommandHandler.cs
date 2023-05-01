using AutoMapper;
using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Application.Validators.Platforms;
using CommanderMinApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.Platforms.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, ServiceResponse<PlatformResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public CreatePlatformCommandHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ServiceResponse<PlatformResponseDTO>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<PlatformResponseDTO>();
            var validator = new CreatePlatformValidator();
            var validationResult = await validator.ValidateAsync(request.platformRequestModel);

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
                var platformForDb = _mapper.Map<PlatformEntity>(request.platformRequestModel);
                _repo.Add(platformForDb);
                response.Data = _mapper.Map<PlatformResponseDTO>(platformForDb);
            }
            return response;
        }
    }
}

using AutoMapper;
using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Application.Validators.Platforms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.Platforms.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, ServiceResponse<PlatformResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public UpdatePlatformCommandHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ServiceResponse<PlatformResponseDTO>> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<PlatformResponseDTO>();
            var validator = new UpdatePlatformValidator();
            var platformFromDb = await _repo.Get(request.platformId);
            var validationResult = await validator.ValidateAsync(request.platformRequestModel);
            if (platformFromDb == null)
            {
                response.Success = false;
                response.Message = "The platform was not found";
            }
            if(validationResult.Errors.Count > 0)
            {
                response.Success = false;
                var errorList = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success && platformFromDb != null)
            {
                _mapper.Map(request.platformRequestModel, platformFromDb);
                _repo.Update(platformFromDb);
            }
            
            return response;
        }
    }
}

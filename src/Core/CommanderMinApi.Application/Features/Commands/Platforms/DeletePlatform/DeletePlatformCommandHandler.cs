using AutoMapper;
using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Commands.Platforms.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, ServiceResponse<PlatformResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public DeletePlatformCommandHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ServiceResponse<PlatformResponseDTO>> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<PlatformResponseDTO>();
            var platformToDelete = await _repo.Get(request.platformId);
            if (platformToDelete == null)
            {
                response.Success = false;
                response.Message = "Platform not found.";
            }
            if (response.Success && platformToDelete != null)
            {
                response.Message = "Platform deleted successfully.";
                _repo.Delete(platformToDelete);
            }

            return response;
        }
    }
}

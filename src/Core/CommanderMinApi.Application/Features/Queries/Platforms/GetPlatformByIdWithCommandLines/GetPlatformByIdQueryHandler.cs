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

namespace CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformByIdWithCommandLines
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, ServiceResponse<PlatformResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public GetPlatformByIdQueryHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ServiceResponse<PlatformResponseDTO>> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<PlatformResponseDTO>();
            var platformFromDb = await _repo.GetPlatformByIdWithCommands(request.platformId);

            if (platformFromDb == null)
            {
                response.Success = false;
                response.Message = "Platform not found!";
            }
            if (response.Success)
            {
                response.Data = _mapper.Map<PlatformResponseDTO>(platformFromDb);
            }
            return response;
        }
    }
}

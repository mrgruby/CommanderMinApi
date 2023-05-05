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

namespace CommanderMinApi.Application.Features.Queries.Platforms.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, ServiceResponse<List<PlatformResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public GetPlatformsListQueryHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ServiceResponse<List<PlatformResponseDTO>>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<List<PlatformResponseDTO>>();
            var platformsFromDb = await _repo.GetPlatformsWithCommands();

            if (platformsFromDb == null)
            {
                response.Success = false;
                response.Message = "No platforms were found!";
            }
            if (response.Success)
            {
                response.Data = _mapper.Map<List<PlatformResponseDTO>>(platformsFromDb);
            }
            return response;
        }
    }
}

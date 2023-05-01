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
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, ServiceResponse<PlatformResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repo;

        public GetPlatformsListQueryHandler(IMapper mapper, IPlatformRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public Task<ServiceResponse<PlatformResponseDTO>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

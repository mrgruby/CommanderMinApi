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

namespace CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineSearchSuggestions
{
    public class GetCommandLineSearchHandler : IRequestHandler<GetCommandLineSearchQuery, PagedListServiceResponse<List<CommandLineResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandLineRepository _repo;

        public GetCommandLineSearchHandler(IMapper mapper, ICommandLineRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<PagedListServiceResponse<List<CommandLineResponseDTO>>> Handle(GetCommandLineSearchQuery request, CancellationToken cancellationToken)
        {
            var response = new PagedListServiceResponse<List<CommandLineResponseDTO>>();
            var commands = await _repo.FindCommandLinesBySearchText(request.SearchText);

            var pageCount = Math.Ceiling(commands.Count/request.PageSize);

            var pagedCommands = commands.Skip((request.CurrentPage - 1) * (int)request.PageSize)
                .Take((int)request.PageSize).ToList();

            response.Data = _mapper.Map<List<CommandLineResponseDTO>>(pagedCommands);
            response.TotalPages = (int)pageCount;
            response.CurrentPage = request.CurrentPage;

            
            return response;
        }
    }
}
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
    public class GetCommandLineSearchQuery : IRequest<PagedListServiceResponse<List<CommandLineResponseDTO>>>
    {
        public float PageSize = 10;
        public int CurrentPage { get; set; }
        public string SearchText { get; set; } = string.Empty;
    }
}

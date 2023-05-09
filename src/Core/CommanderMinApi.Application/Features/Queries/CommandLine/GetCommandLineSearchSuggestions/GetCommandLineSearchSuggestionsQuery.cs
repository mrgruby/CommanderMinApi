using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineSearchSuggestions
{
    public record GetCommandLineSearchSuggestionsQuery(string search) : IRequest<ServiceResponse<List<string>>>
    {
    }
}

using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Application.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Features.Queries.CommandLine.GetCommandLineSearchSuggestions
{
    public class GetCommandLineSearchSuggestionsHandler : IRequestHandler<GetCommandLineSearchSuggestionsQuery, ServiceResponse<List<string>>>
    {
        private readonly ICommandLineRepository _repo;

        public GetCommandLineSearchSuggestionsHandler(ICommandLineRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse<List<string>>> Handle(GetCommandLineSearchSuggestionsQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<List<string>>();
            var commands = await _repo.FindCommandLinesBySearchText(request.search);
            var result = new List<string>();
            foreach (var line in commands)
            {
                if (line.HowTo.Contains(request.search, StringComparison.OrdinalIgnoreCase))
                    result.Add(line.HowTo);

                //To search through the description, we need to first remove all the punctuations, and then collect all the individual words in a list.
                //Finally, we need to go through that list and see if any of them conatains the search text. If so, add it to the list of words to return.
                if (line.Comment != null)
                {
                    //Create an array with all the punctuations in the description text. Distinct() gives us just one of each...
                    var punctuations = line.Comment.Where(char.IsPunctuation).Distinct().ToArray();

                    //Create a list of words, without the punctuations.
                    var words = line.Comment.Split().Select(s => s.Trim(punctuations));

                    foreach (var word in words)
                    {
                        if (word.Contains(request.search, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                            result.Add(word);
                    }
                }
            }
            response.Data = result;
            return response;
        }
    }
}

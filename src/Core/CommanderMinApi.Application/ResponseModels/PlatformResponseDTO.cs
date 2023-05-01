using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.ResponseModels
{
    public record PlatformResponseDTO(
        Guid platformId, 
        string platformName, 
        string platformImageUrl, 
        string PlatformDescription, 
        ICollection<CommandLineResponseDTO>? CommandLineList);
}
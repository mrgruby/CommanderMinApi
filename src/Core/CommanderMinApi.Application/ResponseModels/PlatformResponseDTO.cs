using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.ResponseModels
{
    public record PlatformResponseDTO(
        Guid PlatformId, 
        string PlatformName, 
        string PlatformImageUrl, 
        string PlatformDescription, 
        ICollection<CommandLineResponseDTO>? CommandLineList);
}
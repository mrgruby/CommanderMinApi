using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.ResponseModels
{
    public record CommandLineResponseDTO
    (
        Guid CommandLineId,
        string howTo,
        string line,
        string platformName,
        string Comment,
        Guid platformId
    );
}

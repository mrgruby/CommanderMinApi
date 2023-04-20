using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.RequestModels.Platforms
{
    public record UpdatePlatformRequestModel(string platformName, string platformImageUrl);
}
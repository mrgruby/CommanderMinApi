using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.RequestModels.CommandLines
{
    public record UpdateCommandLineRequestModel(string howTo, string commandLine, string comment);
}

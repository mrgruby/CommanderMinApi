using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence
{
    public interface ICommandLineRepository : IGenericRepository<CommandLine, Guid>
    {
        Task<IEnumerable<CommandLine>> GetCommandLineListByPlatform(Guid platformId);
        Task<CommandLine> GetCommandLineByPlatform(Guid platformId, Guid commandLineId);
    }
}

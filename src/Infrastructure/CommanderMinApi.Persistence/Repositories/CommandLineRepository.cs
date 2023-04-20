using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class CommandLineRepository : GenericRepository<CommandLine, Guid>, ICommandLineRepository
    {
        Task<CommandLine> ICommandLineRepository.GetCommandLineByPlatform(Guid platformId, Guid commandLineId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CommandLine>> ICommandLineRepository.GetCommandLineListByPlatform(Guid platformId)
        {
            throw new NotImplementedException();
        }
    }
}

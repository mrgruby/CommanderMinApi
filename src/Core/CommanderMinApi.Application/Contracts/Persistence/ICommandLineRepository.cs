using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence
{
    public interface ICommandLineRepository : IGenericRepository<CommandLineEntity>
    {
        Task<IEnumerable<CommandLineEntity>> GetCommandLineListByPlatform(Guid platformId);
        Task<CommandLineEntity> GetCommandLineByPlatform(Guid platformId, Guid commandLineId);
        Task<List<CommandLineEntity>> FindCommandLinesBySearchText(string searchText);
    }
}

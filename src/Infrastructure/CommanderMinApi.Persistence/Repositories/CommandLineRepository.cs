using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class CommandLineRepository : GenericRepository<CommandLine>, ICommandLineRepository
    {
        public CommandLineRepository(CommanderMinApiDbContext context) : base(context)
        {

        }
        public async Task<CommandLine> GetCommandLineByPlatform(Guid platformId, Guid commandLineId)
        {
            return await _context.CommandLines.Where(c => c.PlatformId == platformId && c.CommandLineId == commandLineId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CommandLine>> GetCommandLineListByPlatform(Guid platformId)
        {
            return await _context.CommandLines.Where(c => c.PlatformId == platformId).ToListAsync();
        }
    }
}

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
    public class CommandLineRepository : GenericRepository<CommandLineEntity>, ICommandLineRepository
    {
        public CommandLineRepository(CommanderMinApiDbContext context) : base(context)
        {
            
        }

        public async Task<List<CommandLineEntity>> FindCommandLinesBySearchText(string searchText)
        {
            return await _context.CommandLines
                .Where(c => c.CommandLine.Contains(searchText) || c.Comment.Contains(searchText) || c.HowTo.Contains(searchText)).ToListAsync();
        }

        public async Task<CommandLineEntity> GetCommandLineByPlatform(Guid platformId, Guid commandLineId)
        {
            return await _context.CommandLines.Where(c => c.PlatformId == platformId && c.CommandLineId == commandLineId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CommandLineEntity>> GetCommandLineListByPlatform(Guid platformId)
        {
            return await _context.CommandLines.Where(c => c.PlatformId == platformId).ToListAsync();
        }
    }
}

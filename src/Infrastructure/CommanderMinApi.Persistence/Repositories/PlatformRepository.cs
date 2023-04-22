using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(CommanderMinApiDbContext context) : base(context)
        {
            
        }
        public async Task<Platform> GetPlatformByIdWithCommands(Guid platformId)
        {
            var platform = await _context.Platforms.Where(p => p.PlatformId == platformId).Include(c => c.CommandLineList).FirstOrDefaultAsync();
            if (platformId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(platformId));
            }

            return platform;
        }

        public async Task<IEnumerable<Platform>> GetPlatformsWithCommands()
        {
            return await _context.Platforms.ToListAsync();
        }
    }
}

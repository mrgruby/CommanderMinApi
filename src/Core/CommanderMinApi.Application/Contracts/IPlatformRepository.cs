using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts
{
    public interface IPlatformRepository : IGenericRepository<Platform>
    {
        Task<IEnumerable<Platform>> GetPlatformsWithCommands();

        Task<Platform> GetPlatformByIdWithCommands(Guid platformId);
    }
}

using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence
{
    public interface IPlatformRepository : IGenericRepository<PlatformEntity>
    {
        Task<IEnumerable<PlatformEntity>> GetPlatformsWithCommands();

        Task<PlatformEntity> GetPlatformByIdWithCommands(Guid platformId);
    }
}

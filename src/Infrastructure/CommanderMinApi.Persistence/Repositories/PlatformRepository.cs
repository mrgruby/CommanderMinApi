using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class PlatformRepository<T, T2> : GenericRepository<Platform, Guid>, IPlatformRepository
    {
        Task<Platform> IPlatformRepository.GetPlatformByIdWithCommands(Guid platformId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Platform>> IPlatformRepository.GetPlatformsWithCommands()
        {
            throw new NotImplementedException();
        }
    }
}

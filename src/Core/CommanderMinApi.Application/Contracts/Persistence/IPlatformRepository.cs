﻿using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence
{
    public interface IPlatformRepository : IGenericRepository<Platform, Guid>
    {
        Task<IEnumerable<Platform>> GetPlatformsWithCommands();

        Task<Platform> GetPlatformByIdWithCommands(Guid platformId);
    }
}
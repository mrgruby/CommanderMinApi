﻿using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts
{
    public interface ICommandLineRepository : IGenericRepository<CommandLine>
    {
        Task<IEnumerable<CommandLine>> GetCommandLineListByPlatform(Guid platformId);
        Task<CommandLine> GetCommandLineByPlatform(Guid platformId, Guid commandLineId);
    }
}
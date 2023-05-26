using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence.Authentication
{
    public interface IUserRepository
    {
        Task<CommanderUser>GetCommanderUser(string username);
        void AddUser(CommanderUser user);

        void Update(CommanderUser user);
    }
}

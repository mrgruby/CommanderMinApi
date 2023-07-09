using CommanderMinApi.Domain.Entities;

namespace CommanderMinApi.Application.Contracts.Persistence.Authentication
{
    public interface IUserRepository
    {
        Task<CommanderUser>GetCommanderUser(string username);
        void AddUser(CommanderUser user);
        void Update(CommanderUser user);
    }
}
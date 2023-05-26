using CommanderMinApi.Application.Contracts.Persistence.Authentication;
using CommanderMinApi.Authentication.Persistence;
using CommanderMinApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Authentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationDbContext _context;

        public UserRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public void AddUser(CommanderUser user)
        {
            _context.CommanderUser.Add(user);
            _context.SaveChanges();
        }

        public async Task<CommanderUser> GetCommanderUser(string username)
        {
            return await _context.CommanderUser.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public void Update(CommanderUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}

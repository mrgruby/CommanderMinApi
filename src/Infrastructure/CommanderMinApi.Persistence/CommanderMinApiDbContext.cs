using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence
{
    public class CommanderMinApiDbContext : DbContext
    {
        public CommanderMinApiDbContext(DbContextOptions<CommanderMinApiDbContext> options) : base(options)
        {
            
        }
    }
}
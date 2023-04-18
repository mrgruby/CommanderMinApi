using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommanderMinApiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CommanderConnectionString")));

            var assembly = typeof(RegisterPersistenceServices).Assembly;

            return services;
        }
    }
}

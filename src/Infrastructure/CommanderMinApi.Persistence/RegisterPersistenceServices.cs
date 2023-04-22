using CommanderMinApi.Application.Contracts.Persistence;
using CommanderMinApi.Persistence.Repositories;
using FluentValidation;
using Microsoft.Data.SqlClient;
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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<ICommandLineRepository, CommandLineRepository>();

            var assembly = typeof(RegisterPersistenceServices).Assembly;

            return services;
        }
    }
}

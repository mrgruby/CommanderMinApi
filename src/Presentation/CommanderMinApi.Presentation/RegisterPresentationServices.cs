using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Presentation
{
    public static class RegisterPresentationServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}

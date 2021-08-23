using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Repository;

namespace Working.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Repository;
using Working.Service;

namespace Working.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}

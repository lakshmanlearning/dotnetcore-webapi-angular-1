using DotNet_WebAPI_Angular_APIServices;
using DotNet_WebAPI_Angular_InterfaceContracts.Repo;
using DotNet_WebAPI_Angular_InterfaceContracts.Service;
using DotNet_WebAPI_Angular_Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular.AppBuilderExtensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IMemberRepo, MemberRepo>();

            return services;
        }
    }
}

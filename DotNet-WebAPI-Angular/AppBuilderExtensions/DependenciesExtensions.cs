using DotNet_WebAPI_Angular_APIServices;
using DotNet_WebAPI_Angular_InterfaceContracts.Generic;
using DotNet_WebAPI_Angular_InterfaceContracts.Repo;
using DotNet_WebAPI_Angular_InterfaceContracts.Service;
using DotNet_WebAPI_Angular_Repo;
using DotNet_WebAPI_Angular_Repo.Generic;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IMemberRepo, MemberRepo>();

            return services;
        }
    }
}

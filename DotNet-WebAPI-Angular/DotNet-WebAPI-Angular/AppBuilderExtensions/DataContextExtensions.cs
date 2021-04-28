using DotNet_WebAPI_Angular_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular.AppBuilderExtensions
{
    public static class DataContextExtensions
    {
        public static IServiceCollection ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<MyOnlineShoppingContext>(options =>
            {
                options.UseSqlServer(GetConnectionString(configuration));
            });
            return services;
        }

        public static string GetConnectionString(IConfiguration configuration)
        {
            var ctr = configuration.GetSection("MyConnectionString").Value;
            return ctr;
        }
    }
}

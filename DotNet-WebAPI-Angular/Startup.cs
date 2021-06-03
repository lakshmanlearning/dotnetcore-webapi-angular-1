using AutoMapper;
using DotNet_WebAPI_Angular.AppBuilderExtensions;
using DotNet_WebAPI_Angular.Models;
using DotNet_WebAPI_Angular_APIServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DotNet_WebAPI_Angular
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection("MySettings");
            services.AddAutoMapper(typeof(MemberService).Assembly);
            //services.ConfigureDependencies();
            //services.ConfigureDataContext(config);
            services.AddControllersWithViews();

            services.Configure<AppSettingsOptions>(Configuration.GetSection("MySettings"));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}
            app.UseDeveloperExceptionPage();

            app.Use(async (context, next) => 
            {
                await next();
                if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            if (!env.IsDevelopment() && !env.IsEnvironment("QA") && !env.IsEnvironment("Production"))
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment() || env.IsEnvironment("QA") || env.IsEnvironment("Production"))
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

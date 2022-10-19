using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailRewardsProgram.Data;
using RetailRewardsProgram.Services;
using RetailRewardsProgram.Services.RewardsPrograms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RetailRewardsProgram
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>();
            services.AddTransient<UserSeeder>();
            services.AddTransient<IRewardsProgram, RewardsProgram2022>(); // Add the RewardsProgram2022 class as an injectable service
            services.AddScoped<IUserRepository,UserRepository>(); // Make sure we reuse the repository through the scope 
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Only show the developer exception page while debugging
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
               
                cfg.MapControllerRoute("Default", "/{controller}/{action}/{id?}", new { controller = "App", action = "Index" }); 
            }); 
        }
    }
}

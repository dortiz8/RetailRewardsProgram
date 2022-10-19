using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging;
using RetailRewardsProgram.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RetailRewardsProgram
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            if(args.Length == 1 && args[0].ToLower() == "/seed") RunSeeding(host); // Only seed if we pass argument "/seed" to Main. Could be stored in config.json file
            else host.Run();

        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();  // Creates a scope for the lifetime of the request
            using (var scope = scopeFactory.CreateScope()) // Using to close the scope once we are done
            {
                var seeder = scope.ServiceProvider.GetService<UserSeeder>();
                //seeder.Unseed(); // We can possibly use this to clear out seeded data
                seeder.Seed();
            }
           
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddConfiguration).
                UseStartup<Startup>().Build(); 
                
        private static void AddConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            // Allows us to add different sources for configuration
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables(); // Helps with overriding configuration variables
        }
    }
}

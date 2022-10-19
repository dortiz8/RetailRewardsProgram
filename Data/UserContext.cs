using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetailRewardsProgram.Data.Entities;

namespace RetailRewardsProgram.Data
{
    public class UserContext : DbContext
    {
        private readonly IConfiguration _config;
        public UserContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
       
        // Configure the context to a specific database = UserDb
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:UserContextDb"]); 
        }
        // Specify how the mapping is going to happen between your entities and the db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}

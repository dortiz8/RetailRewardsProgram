using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using RetailRewardsProgram.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RetailRewardsProgram.Data
{
    public class UserSeeder
    {
        private readonly UserContext _ctx;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public UserSeeder(UserContext ctx, IConfiguration config, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _config = config;
            _env = env;
        }
        // Used to clear the current table and seed new data
        public void Unseed()
        {
            _ctx.Purchases.RemoveRange(_ctx.Purchases);
            _ctx.SaveChanges();
        }
        // Create an order 
        public void Seed()
        {
            _ctx.Database.EnsureCreated(); // Make sure db exists

            if (!_ctx.Purchases.Any())
            {
                var path = Path.Combine(_env.ContentRootPath, _config["Paths:JsonPurchases"]);
                //Create sample data 
                var json = File.ReadAllText(path);

                var purchases = JsonSerializer.Deserialize<IEnumerable<Purchase>>(json);

                _ctx.Purchases.AddRange(purchases);

                // Each user gets x number of purchases
                var firstUserPurchases = purchases.Take(3);
                var secondUserPurchases = purchases.Skip(3).Take(3); 
                var thirdUserPurchases = purchases.Skip(6).Take(3); 

                // Instantiate sample users
                var user1 = new User()
                {
                    Name = "Dante Ortiz",
                    PhoneNumber = "930-456-7689",
                    PurchaseHistory = new List<Purchase>(firstUserPurchases)
                };
                var user2 = new User()
                {
                    Name = "John Doe",
                    PhoneNumber = "930-223-7089",
                    PurchaseHistory = new List<Purchase>(secondUserPurchases)
                };
                var user3 = new User()
                {
                    Name = "Jay Smith",
                    PhoneNumber = "930-223-4560",
                    PurchaseHistory = new List<Purchase>(thirdUserPurchases)
                };

                var userRange = new List<User>()
                {
                    user1, user2, user3
                }; 

                _ctx.Users.AddRange(userRange); 

                _ctx.SaveChanges(); 
            }
        }
    }
}

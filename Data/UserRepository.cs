using RetailRewardsProgram.Data.Entities;
using RetailRewardsProgram.Services;
using RetailRewardsProgram.Services.RewardsPrograms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RetailRewardsProgram.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _ctx;
        private readonly IRewardsProgram _rewardsProgramService;

        public UserRepository(UserContext ctx, IRewardsProgram rewardsProgramService)
        {
            _ctx = ctx;
            _rewardsProgramService = rewardsProgramService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users.OrderBy(u => u.Name).ToList();
        }

        public User GetUserById(int Id)
        {
            User user = _ctx.Users.Where(u => u.Id == Id).FirstOrDefault();
            if(user != null)
            {
                List<Purchase> purchases = GetPurchasesById(Id);
                user.PurchaseHistory = purchases; 
            }
            return user;
        }

        public List<Purchase> GetPurchasesById(int Id)
        {
            return _ctx.Purchases.Where(u => u.UserId == Id).ToList();  
        }

        public IEnumerable<User> GetAllUsersAndTheirPurchases()
        {
            IEnumerable<User> users = GetAllUsers();
            if (users.Any())
            {
                foreach(var user in users)
                {
                    user.PurchaseHistory = GetPurchasesById(user.Id);
                    if(user.PurchaseHistory != null) user.Points = GetRewardsPoints(user.PurchaseHistory); 
                }
                
            }
            
            return users; 
        }

        private int GetRewardsPoints(IEnumerable<Purchase> purchaseHistory)
        {
            return _rewardsProgramService.CalculateRewards(purchaseHistory); 
        }

        public bool SaveAllChanges()
        {
            return _ctx.SaveChanges() > 0; 
        }
    }
}

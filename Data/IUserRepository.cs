using RetailRewardsProgram.Data.Entities;
using System.Collections.Generic;

namespace RetailRewardsProgram.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int Id);
        bool SaveAllChanges();
        IEnumerable<User> GetAllUsersAndTheirPurchases(); 
    }
}
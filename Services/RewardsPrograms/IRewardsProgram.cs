using RetailRewardsProgram.Data.Entities;
using System.Collections.Generic;

namespace RetailRewardsProgram.Services.RewardsPrograms
{
    public interface IRewardsProgram
    {
        public int CalculateRewards(IEnumerable<Purchase>  purchaseHistory); 
    }
}

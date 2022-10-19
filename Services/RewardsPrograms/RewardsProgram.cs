using Microsoft.AspNetCore.Routing;
using RetailRewardsProgram.Data.Entities;
using RetailRewardsProgram.Services.RewardsPrograms;
using System;
using System.Collections.Generic;

namespace RetailRewardsProgram.Services
{
    public class RewardsProgram2022 : IRewardsProgram
    {
        public int CalculateRewards(IEnumerable<Purchase> purchaseHistory)
        {
            // A customer must spend at least $101 to gain points on each transaction
            // Two points for every dollar spent over 100
            // Plus one point for every dollar spent over 50
            var regularPoints = 0;
            var doublePoints = 0;
            foreach (Purchase purchase in purchaseHistory)
            {
                if(purchase.Cost > 100)
                {
                    doublePoints += ((int)Math.Floor(purchase.Cost) - 100) * 2;
                    regularPoints += 50;
                }
            }

            return regularPoints + doublePoints;
        }

    }

    // Add logic to calculate the monthly total reward points... 
}

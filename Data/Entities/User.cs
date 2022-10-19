using System.Collections.Generic;

namespace RetailRewardsProgram.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Purchase> PurchaseHistory { get; set; }
        public int Points { get; set; }
    }
}

using System;

namespace RetailRewardsProgram.Data.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime MonthDate { get; set; }
        public decimal Cost { get; set; }
        public int UserId { get; set; }
    }
}

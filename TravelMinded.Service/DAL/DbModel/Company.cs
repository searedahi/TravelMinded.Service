using System.Collections.Generic;

namespace TravelMinded.Service.DAL.DbModel
{
    public class Company : BaseDbModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
        public bool IsFareHarborVendor { get; set; }

        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

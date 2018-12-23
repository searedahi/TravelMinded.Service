using System.Collections.Generic;

namespace TravelMinded.Service.DAL.DbModel
{
    public class Product : BaseDbModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public Company Company { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

    }
}

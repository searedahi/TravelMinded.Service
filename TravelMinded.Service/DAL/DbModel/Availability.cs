using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelMinded.Service.DAL.DbModel
{
    public class Availability : BaseDbModel
    {
        /// <summary>
        /// Fareharbor primary key.
        /// </summary>
        public int Pk { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<CustomerTypeRate> CustomerTypeRates { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Experience Experience { get; set; }


    }
}

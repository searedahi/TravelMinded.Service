using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelMinded.Service.DAL.DbModel
{
    public class Experience : BaseDbModel
    {
        /// <summary>
        /// Fareharbor primary key.
        /// </summary>
        public int Pk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
        public string ShortName { get; set; }
        public decimal Price { get; set; }
        public Company Company { get; set; }
        public string Headline { get; set; }
        public string DescriptionSafeHtml { get; set; }
        public string DescriptionText { get; set; }
        public string CancellationPolicy { get; set; }
        public string CancellationPolicySafeHtml { get; set; }
        public string ImageCdnUrl { get; set; }
        public bool IsPickupEverOffered { get; set; }
        public decimal TaxPercentage { get; set; }

        [NotMapped]
        public ICollection<string> DescriptionBullets { get; set; }
        public ICollection<CustomerPrototype> CustomerPrototypes { get; set; }
        public ICollection<ImageInfo> Images { get; set; }
        public ICollection<LocationInfo> Locations { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<ProTip> ProTips { get; set; }

    }
}

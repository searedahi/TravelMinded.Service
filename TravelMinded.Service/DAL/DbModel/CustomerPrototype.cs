using System.ComponentModel.DataAnnotations.Schema;

namespace TravelMinded.Service.DAL.DbModel
{
    public class CustomerPrototype : BaseDbModel
    {
        /// <summary>
        /// Fareharbor primary key.
        /// </summary>
        public int Pk { get; set; }
        public string DisplayName { get; set; }
        public int Total { get; set; }
        [NotMapped]
        public int TravelMindedCustomerTypeId { get; set; }
    }
}

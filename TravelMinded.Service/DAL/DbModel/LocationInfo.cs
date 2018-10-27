namespace TravelMinded.Service.DAL.DbModel
{
    public class LocationInfo : BaseDbModel
    {
        /// <summary>
        /// Fareharbor primary key.
        /// </summary>
        public int Pk { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string NoteSafeHtml { get; set; }
        public AddressInfo Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string GooglePlaceId { get; set; }
        public string TripadvisorUrl { get; set; }
    }
}

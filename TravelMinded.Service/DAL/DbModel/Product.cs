namespace TravelMinded.Service.DAL.DbModel
{
    public class Product : BaseDbModel
    {
        public string ShortName { get; set; }
        public string Currency { get; set; }
        public Company Company { get; set; }
    }
}

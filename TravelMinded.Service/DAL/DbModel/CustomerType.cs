namespace TravelMinded.Service.DAL.DbModel
{
    public class CustomerType : BaseDbModel
    {
        public int pk { get; set; }
        public string singular { get; set; }
        public string plural { get; set; }
        public string note { get; set; }
    }
}

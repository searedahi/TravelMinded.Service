namespace TravelMinded.Service.DAL.DbModel
{
    public class CustomerTypeRate : BaseDbModel
    {
        public int pk { get; set; }
        public int total { get; set; }
        public int capacity { get; set; }
        public CustomerPrototype customer_prototype { get; set; }
        public CustomerType customer_type { get; set; }
    }
}

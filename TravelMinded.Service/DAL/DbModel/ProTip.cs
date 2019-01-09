namespace TravelMinded.Service.DAL.DbModel
{
    public class ProTip : BaseDbModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }

        public Experience Experience { get; set; }
        public Product Product { get; set; }
    }
}

namespace TravelMinded.Service.DAL.DbModel
{
    public class ImageInfo : BaseDbModel
    {
        public int Pk { get; set; }
        public string Gallery { get; set; }
        public string ImageCdnUrl { get; set; }
    }
}

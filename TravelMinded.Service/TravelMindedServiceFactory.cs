namespace TravelMinded.Service
{
    public static class TravelMindedServiceFactory
    {
        public static TravelMindedRepository CreateTravelMindedService()
        {
            //var dbOptions = new DbContextOptions<DAL.TravelMindedContext>();            
            var dbContext = new DAL.TravelMindedContext();
            var tmService = new TravelMindedRepository(dbContext);
            return tmService;
        }

    }
}

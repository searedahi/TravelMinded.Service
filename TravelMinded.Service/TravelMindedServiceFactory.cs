using Microsoft.EntityFrameworkCore;

namespace TravelMinded.Service
{
    public static class TravelMindedServiceFactory
    {
        public static TravelMindedService CreateTravelMindedService()
        {
            //var dbOptions = new DbContextOptions<DAL.TravelMindedContext>();            
            var dbContext = new DAL.TravelMindedContext();
            var tmService = new TravelMindedService(dbContext);
            return tmService;
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelMinded.Service.Test
{
    [TestClass]
    public class TravelMindedSeedsTest
    {
        [TestMethod]
        public void TestTheSeeds()
        {
            var seeder = new TravelMinded.Service.DAL.TravelMindedSeeds();

            var records = seeder.SeedCompaniesFromFareHarbor();

            Assert.IsTrue(records > 0);
        }
    }
}

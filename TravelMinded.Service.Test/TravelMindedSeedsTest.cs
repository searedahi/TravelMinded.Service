using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelMinded.Service.Test
{
    [TestClass]
    public class TravelMindedSeedsTest
    {
        [TestMethod]
        public void TestTheCompanySeeds()
        {
            var seeder = new TravelMinded.Service.DAL.TravelMindedSeeds();

            var records = seeder.SeedCompaniesFromFareHarbor();

            Assert.IsTrue(records > 0);
        }

        [TestMethod]
        public void TestTheExperienceSeeds()
        {
            var seeder = new TravelMinded.Service.DAL.TravelMindedSeeds();

            var records = seeder.SeedExperiencesFromFareHarbor();

            Assert.IsTrue(records > 0);
        }

        [TestMethod]
        public void TestTheAvailabilitySeeds()
        {
            var seeder = new TravelMinded.Service.DAL.TravelMindedSeeds();

            var records = seeder.SeedAvailabilitiesFromFareHarbor();

            Assert.IsTrue(records > 0);
        }







        [TestMethod]
        public void TestTheAllSeeds()
        {
            var seeder = new TravelMinded.Service.DAL.TravelMindedSeeds();

            var companies = seeder.SeedCompaniesFromFareHarbor();

            var experiences = seeder.SeedExperiencesFromFareHarbor();

            var availablilties = seeder.SeedAvailabilitiesFromFareHarbor();

            Assert.IsTrue(companies > 0);
            Assert.IsTrue(experiences> 0);
            Assert.IsTrue(availablilties > 0);
        }

    }
}

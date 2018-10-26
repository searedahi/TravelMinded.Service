using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelMinded.Service.Test
{
    [TestClass]
    public class TestingDb
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tmSvc = TravelMindedServiceFactory.CreateTravelMindedService();
            var company = tmSvc.GetCompany();
            Assert.IsNotNull(company);
        }
    }
}

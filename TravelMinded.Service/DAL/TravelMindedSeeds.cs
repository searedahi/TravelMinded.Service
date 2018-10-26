using System.Collections.Generic;
using System.Linq;

namespace TravelMinded.Service.DAL
{
    public class TravelMindedSeeds
    {
        public int SeedCompaniesFromFareHarbor()
        {
            var tmContext = new TravelMindedContext();

            if (tmContext.Companies.Any())
            {
                return 0;
            }

            var fareHarborSvc = FareHarborService.FareHarborRestServiceFactory.CreateFareHarborRestService();

            var fareHarborCompanies = fareHarborSvc.GetCompanies();

            var fareHarborCompaniesDetails = new List<FareHarborService.Models.CompanyDetail>();

            foreach (var fhCo in fareHarborCompanies)
            {
                var companyDetails = fareHarborSvc.GetCompany(fhCo.shortname);
                fareHarborCompaniesDetails.Add(companyDetails);
            }

            foreach (var companyDetail in fareHarborCompaniesDetails)
            {
                var dbCo = new DAL.DbModel.Company();
                dbCo.Name = companyDetail.name;
                dbCo.ShortName = companyDetail.shortname;
                dbCo.Currency = companyDetail.currency;

                tmContext.Add(dbCo);
            }

            var recordsSaved = tmContext.SaveChanges();
            return recordsSaved;
        }
    }
}

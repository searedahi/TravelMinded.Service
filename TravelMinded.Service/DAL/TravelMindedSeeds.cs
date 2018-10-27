using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;

namespace TravelMinded.Service.DAL
{
    public class TravelMindedSeeds
    {
        private IMapper mapper;

        public TravelMindedSeeds()
        {
            mapper = ObjectMapper.CreateMapper();
        }

        public MapperConfiguration ObjectMapper
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.IgnoreUnmapped();
                    cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

                    cfg.CreateMap<Company, DbModel.Company>();
                    cfg.CreateMap<Company, DbModel.Company>();
                    cfg.CreateMap<Company[], List<DbModel.Company>>();
                    cfg.CreateMap<Experience, DbModel.Experience>();
                    cfg.CreateMap<List<Experience>, List<DbModel.Experience>>();
                    cfg.CreateMap<ImageInfo, DbModel.ImageInfo>();
                    cfg.CreateMap<LocationInfo, DbModel.LocationInfo>();
                    cfg.CreateMap<CustomerPrototype, DbModel.CustomerPrototype>();
                });
            }
        }

        public int SeedCompaniesFromFareHarbor()
        {
            var tmContext = new TravelMindedContext();

            if (tmContext.Companies.Any())
            {
                foreach (var exper in tmContext.Companies.ToList())
                {
                    tmContext.Companies.Remove(exper);
                }
                var recCount = tmContext.SaveChanges();

                //throw new Exception("There are already companies in the database.");
            }

            var fareHarborSvc = FareHarborService.FareHarborRestServiceFactory.CreateFareHarborRestService();

            var fareHarborCompanies = fareHarborSvc.GetCompanies();

            var fareHarborCompaniesDetails = new List<FareHarborService.Models.CompanyDetail>();

            foreach (var fhCo in fareHarborCompanies)
            {
                var companyDetail = fareHarborSvc.GetCompany(fhCo.ShortName);

                var dbCo = mapper.Map<DbModel.Company>(companyDetail);
                dbCo.IsFareHarborVendor = true;

                tmContext.Add(dbCo);
            }

            var recordsSaved = tmContext.SaveChanges();
            return recordsSaved;
        }

        public int SeedExperiencesFromFareHarbor()
        {
            var tmContext = new TravelMindedContext();

            if (tmContext.Experiences.Any())
            {
                foreach (var exper in tmContext.Experiences.ToList())
                {
                    tmContext.Experiences.Remove(exper);
                }
                var recCount = tmContext.SaveChanges();
                //throw new Exception("There are already experiences i nthe database.");
            }

            var fareHarborSvc = FareHarborService.FareHarborRestServiceFactory.CreateFareHarborRestService();

            var companies = tmContext.Companies.Where(c => c.IsFareHarborVendor).ToList();

            var allExperiences = new List<IExperience>();

            foreach (var company in companies)
            {
                var fareHarborExperiences = fareHarborSvc.GetComanyItems(company.ShortName);

                foreach (var companyExperience in fareHarborExperiences)
                {
                    var dbExperience = mapper.Map<DbModel.Experience>(companyExperience);
                    dbExperience.Company = company;

                    tmContext.Experiences.Add(dbExperience);
                }
            }

            var recordsSaved = tmContext.SaveChanges();
            return recordsSaved;

        }
    }
}

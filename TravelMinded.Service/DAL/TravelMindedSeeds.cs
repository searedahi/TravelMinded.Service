using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var dbList = new List<DbModel.Experience>();


            Parallel.ForEach(companies, co =>
            {

                var fareHarborExperiences = fareHarborSvc.GetComanyItems(co.ShortName);

                Parallel.ForEach(fareHarborExperiences, fa =>
                {
                    var dbExperience = mapper.Map<DbModel.Experience>(fa);
                    dbExperience.Company = co;

                    dbList.Add(dbExperience);
                });

            });

            tmContext.Experiences.AddRange(dbList);

            //foreach (var company in companies)
            //{
            //    var fareHarborExperiences = fareHarborSvc.GetComanyItems(company.ShortName);

            //    foreach (var companyExperience in fareHarborExperiences)
            //    {
            //        var dbExperience = mapper.Map<DbModel.Experience>(companyExperience);
            //        dbExperience.Company = company;

            //        tmContext.Experiences.Add(dbExperience);
            //    }
            //}

            var recordsSaved = tmContext.SaveChanges();
            return recordsSaved;

        }

        public int SeedAvailabilitiesFromFareHarbor()
        {
            var tmContext = new TravelMindedContext();

            //if (tmContext.Availabilities.Any())
            //{
            //    foreach (var available in tmContext.Availabilities.ToList())
            //    {
            //        tmContext.Availabilities.Remove(available);
            //    }
            //    var recCount = tmContext.SaveChanges();
            //    //throw new Exception("There are already experiences in the database.");
            //}

            var fareHarborSvc = FareHarborService.FareHarborRestServiceFactory.CreateFareHarborRestService();

            var companies = tmContext.Companies.Where(c => c.IsFareHarborVendor).ToList();

            var allExperiences = new List<IExperience>();
            var recordsSaved = 0;

            foreach (var company in companies)
            {
                var companyExperiences = tmContext.Experiences.Where(e => e.Company.Equals(company)).ToList();

                var dbAvailList = new List<DbModel.Availability>();

                Parallel.ForEach(companyExperiences, companyExperience =>
                {
                    var availabilities = new List<IAvailability>();

                    var items = new List<IAvailability>();

                    DateTime targetDt = DateTime.Now;

                    var datesList = new List<DateTime>
                    {
                        targetDt
                    };

                    while (targetDt < DateTime.Now.AddDays(30))
                    {
                        targetDt = targetDt.AddDays(1);
                        datesList.Add(targetDt);
                    }

                    Parallel.ForEach(datesList, target =>
                    {
                        var expAvailabilities = fareHarborSvc.GetExperienceAvailabilities(company.ShortName, companyExperience.Pk, targetDt);
                        if (expAvailabilities.Any())
                        {
                            // Check the experience duration, make sure its set
                            // use the first availablility as needed.
                            if (companyExperience.Duration == 0)
                            {
                                var firstAvail = expAvailabilities.FirstOrDefault();

                                var parsedStart = DateTime.Parse(firstAvail.StartAt);
                                var parsedEnd = DateTime.Parse(firstAvail.EndAt);

                                var duration = parsedEnd - parsedStart;
                                companyExperience.Duration = Convert.ToInt32(duration.TotalMinutes);
                            }

                            foreach (var fhExp in expAvailabilities)
                            {
                                var dbAvailability = mapper.Map<DbModel.Availability>(fhExp);
                                dbAvailability.Experience = companyExperience;

                                dbAvailList.Add(dbAvailability);
                            }
                        }
                    });

                });

                tmContext.Availabilities.AddRange(dbAvailList);

            };



            recordsSaved += tmContext.SaveChanges();

            return recordsSaved;
        }
    }
}

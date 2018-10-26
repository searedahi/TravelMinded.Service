using AutoMapper;
using Experience.Models;
using System.Linq;
using TravelMinded.Service.DAL;

namespace TravelMinded.Service
{
    public class TravelMindedService
    {
        private TravelMindedContext dbContext;

        public TravelMindedService(TravelMindedContext travelMindedContext)
        {
            dbContext = travelMindedContext;
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.DbModel.Company, Company>());
        }


        public Company GetCompany()
        {
            var company = new Company();

            var dbCompany = dbContext.Companies.FirstOrDefault();

            if (dbCompany != null)
            {
                company = Mapper.Map<Company>(dbCompany);
            }

            return company;
        }
    }
}

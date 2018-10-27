using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;
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
            Mapper.Initialize(cfg => cfg.CreateMap<List<DAL.DbModel.Experience>, List<Experience>>());
        }


        public ICompany GetCompany()
        {
            var company = new Company();

            var dbCompany = dbContext.Companies.FirstOrDefault();

            if (dbCompany != null)
            {
                company = Mapper.Map<Company>(dbCompany);
            }

            return company;
        }



        public IList<IExperience> GetExperiences()
        {
            var experiences = new List<Experience>();

            var dbExperiences = dbContext.Experiences.ToList();

            if (dbExperiences != null)
            {
                experiences = Mapper.Map<List<Experience>>(dbExperiences);
            }

            return experiences as IList<IExperience>;
        }

    }
}

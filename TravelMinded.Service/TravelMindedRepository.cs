using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;
using TravelMinded.Service.DAL;

namespace TravelMinded.Service
{
    public class TravelMindedRepository : ITravelMindedRepository
    {
        private TravelMindedContext dbContext;
        private IMapper mapper;

        public TravelMindedRepository(TravelMindedContext travelMindedContext)
        {
            dbContext = travelMindedContext;
            mapper = new Mapper(TravelMindedMapperFactory.MapperConfig());
        }


        public ICompany GetCompany()
        {
            var company = new Company();

            var dbCompany = dbContext.Companies.FirstOrDefault();

            if (dbCompany != null)
            {
                company = mapper.Map<Company>(dbCompany);
            }

            return company;
        }



        public IList<IExperience> GetExperiences()
        {
            IList<IExperience> experiences = new List<IExperience>();

            var dbExperiences = dbContext.Experiences
                .Include(e => e.Company)
                .Include(e => e.Images)
                .ToList();

            if (dbExperiences != null)
            {
                foreach (var experience in dbExperiences)
                {
                    var futureAvailabilities = dbContext.Availabilities
                        .Where(a => experience.Id.Equals(a.Experience.Id)
                                    && DateTime.Parse(a.StartAt) > DateTime.Now
                            )
                        .ToList();

                    experience.Availabilities = futureAvailabilities;

                    var expMap = mapper.Map<Experience>(experience);
                    experiences.Add(expMap);
                }
            }

            var orderedExperiences = experiences.OrderBy(e => e.NextAvailableDate).ToList();

            return orderedExperiences;
        }

        public IExperience GetExperience(int experienceId)
        {
            IExperience experience = new Experience();

            var dbExp = dbContext.Experiences
                .Include(e => e.Company)
                .Include(e => e.Images)
                .Include(e => e.Availabilities)
                .Include("Availabilities.CustomerTypeRates")
                .Include(e=>e.CustomerPrototypes)
                .Include(e => e.ProTips)

                .FirstOrDefault(e => e.Id.Equals(experienceId));

            if (dbExp != null)
            {
                var pastAvailabilities = dbExp.Availabilities.Where(a => DateTime.Parse(a.StartAt) < DateTime.Now).ToList();

                foreach (var avail in pastAvailabilities)
                {
                    dbExp.Availabilities.Remove(avail);
                }

                experience = mapper.Map<Experience>(dbExp);
            }

            return experience;
        }

    }
}

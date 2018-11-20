using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;
using TravelMinded.Service.DAL;

namespace TravelMinded.Service
{
    public class TravelMindedService
    {
        private TravelMindedContext dbContext;
        private IMapper mapper;

        public TravelMindedService(TravelMindedContext travelMindedContext)
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
                            && DateTime.Parse(a.StartAt) > DateTime.Now)
                        .ToList();

                    experience.Availabilities = futureAvailabilities;

                    var expMap = mapper.Map<Experience>(experience);
                    experiences.Add(expMap);
                }
                //experiences = mapper.Map<List<Experience>>(dbExperiences);
            }

            return experiences.OrderBy(e => e.NextAvailableDate).ToList();
        }

        public IExperience GetExperience(int experienceId)
        {
            IExperience experience = new Experience();

            var dbExp = dbContext.Experiences
                .Include(e => e.Company)
                .Include(e => e.Images)
                .FirstOrDefault(e => e.Id.Equals(experienceId));

            if (dbExp != null)
            {
                var futureAvailabilities = dbContext.Availabilities
                        .Where(a => experience.Id.Equals(a.Experience.Id)
                            && DateTime.Parse(a.StartAt) > DateTime.Now)
                    .ToList();

                dbExp.Availabilities = futureAvailabilities;

                experience = mapper.Map<Experience>(dbExp);
            }

            return experience;
        }

    }
}

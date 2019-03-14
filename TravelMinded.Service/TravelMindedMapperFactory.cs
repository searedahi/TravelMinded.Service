using AutoMapper;
using System.Collections.Generic;
using Travel.Models;

namespace TravelMinded.Service
{
    public static class TravelMindedMapperFactory
    {
        public static MapperConfiguration MapperConfig()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.IgnoreUnmapped();
                cfg.CreateMap<DAL.DbModel.Company, Company>();
                cfg.CreateMap<List<DAL.DbModel.Experience>, List<Experience>>();
                cfg.CreateMap<List<DAL.DbModel.Availability>, List<Availability>>();
                cfg.CreateMap<List<DAL.DbModel.CustomerPrototype>, List<CustomerPrototype>>();
                cfg.CreateMap<DAL.DbModel.CustomerPrototype, CustomerPrototype>();
                cfg.CreateMap<DAL.DbModel.Experience, Experience>();                
                cfg.CreateMap<DAL.DbModel.Availability, Availability>();
            });

            return mapConfig;
        }
    }
}

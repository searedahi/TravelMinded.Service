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
            });

            return mapConfig;
        }
    }
}

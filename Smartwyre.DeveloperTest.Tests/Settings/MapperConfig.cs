using AutoMapper;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Tests.Settings
{
    public static class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductEntity, Product>();
                cfg.CreateMap<RebateEntity, Rebate>().ReverseMap();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

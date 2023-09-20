using AutoMapper;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Models;


namespace Smartwyre.DeveloperTest.Data.MappProfiles
{
    public class RebateProfile : Profile
    {
        public RebateProfile()
        {
            CreateMap<RebateEntity, Rebate>().ReverseMap();
        }
    }
}

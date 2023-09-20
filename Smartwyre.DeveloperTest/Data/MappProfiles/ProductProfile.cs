using AutoMapper;
using Smartwyre.DeveloperTest.Core.Entities;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Data.MappProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, Product>();
        }
    }
}

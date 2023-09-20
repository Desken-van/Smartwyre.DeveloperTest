using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Core;
using Smartwyre.DeveloperTest.Models;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SWContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductRepository(SWContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext; ;        
            _mapper = mapper;
        }

        public async Task<Product> GetProductByIdentifierAsync(string identifier)
        {
            var product = await _dbcontext.Products.FirstOrDefaultAsync(x => x.Identifier == identifier);


            if (product != null)
            {
                var result = _mapper.Map<Product>(product);

                return result;
            }

            return null;
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Core;
using Smartwyre.DeveloperTest.Models;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data.Repository
{
    public class RebateRepository : IRebateRepository
    {
        private readonly SWContext _dbcontext;
        private readonly IMapper _mapper;

        public RebateRepository(SWContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext; ;
            _mapper = mapper;
        }

        public async Task<Rebate> GetRebateByIdentifierAsync(string identifier)
        {
            var rebate = await _dbcontext.Rebates.FirstOrDefaultAsync(x => x.Identifier == identifier);


            if (rebate != null)
            {
                var result = _mapper.Map<Rebate>(rebate);

                return result;
            }

            return null;
        }

        //public async Task StoreCalculationResult(Rebate account, decimal rebateAmount)
        public async Task StoreCalculationResultAsync(Rebate rebate)
        {
            var original = await _dbcontext.Rebates.FindAsync(rebate.Identifier);
            _dbcontext.Entry(original).CurrentValues.SetValues(rebate);
            await _dbcontext.SaveChangesAsync();
        }

    }
}
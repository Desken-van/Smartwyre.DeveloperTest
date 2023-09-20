using Smartwyre.DeveloperTest.Models;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IRebateRepository
    {
        Task<Rebate> GetRebateByIdentifierAsync(string identifier);
        Task StoreCalculationResultAsync(Rebate account);
    }
}
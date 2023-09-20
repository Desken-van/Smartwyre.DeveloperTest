using Smartwyre.DeveloperTest.Models.Requests;
using Smartwyre.DeveloperTest.Models.Response;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services
{
    public interface IRebateService
    {
        Task<CalculateRebateResponse> CalculateAsync(CalculateRebateRequest request);
    }
}
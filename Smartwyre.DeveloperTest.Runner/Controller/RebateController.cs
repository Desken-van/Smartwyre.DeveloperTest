using Microsoft.AspNetCore.Mvc;
using Smartwyre.DeveloperTest.Models.Requests;
using Smartwyre.DeveloperTest.Models.Response;
using Smartwyre.DeveloperTest.Services;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Runner.Controller
{
    public class RebateController : ControllerBase
    {
        private readonly IRebateService _rebateService;

        public RebateController(IRebateService rebateService)
        {
            _rebateService = rebateService;
        }

        [HttpGet("api/rebate/calculate")]
        public async Task<CalculateRebateResponse> CalculateRebate(CalculateRebateRequest request)
        {
            var response = await _rebateService.CalculateAsync(request);

            return response;
        }
    }
}

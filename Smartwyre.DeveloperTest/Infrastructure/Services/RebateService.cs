using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Infrastructure.Factory.Base;
using Smartwyre.DeveloperTest.Models;
using Smartwyre.DeveloperTest.Models.Requests;
using Smartwyre.DeveloperTest.Models.Response;
using Smartwyre.DeveloperTest.Services;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Infrastructure.Services
{
    public class RebateService : IRebateService
    {
        private readonly IRebateRepository _rebateRepository;
        private readonly IProductRepository _productRepository;

        public RebateService(IRebateRepository rebateRepository, IProductRepository productRepository)
        {
            _rebateRepository = rebateRepository;
            _productRepository = productRepository;
        }

        public async Task<CalculateRebateResponse> CalculateAsync(CalculateRebateRequest request)
        {
            var rebate = await _rebateRepository.GetRebateByIdentifierAsync(request.RebateIdentifier);
            var product = await _productRepository.GetProductByIdentifierAsync(request.ProductIdentifier);

            var result = new CalculateRebateResponse();

            var rebateAmount = 0m;

            if (rebate != null || product != null)
            {

                var calcresult = CheckingResultSuccess(rebate, product, request.Volume);

                if (calcresult != null)
                {
                    rebateAmount = calcresult.Amount;
                    result.Success = calcresult.Success;
                }

                if (result.Success)
                {
                    rebate.Amount = rebateAmount;

                    await _rebateRepository.StoreCalculationResultAsync(rebate);
                }
            }
            else
            {
                result.Success = false;
            }

            return result;
        }

        private IncetiveCalculationResult CheckingResultSuccess(Rebate rebate, Product product, decimal volume)
        {
            var result = new IncetiveCalculationResult();

            var calculator = IncentiveFactory.CreateIncentive(rebate.Incentive);

            result = calculator.CalculateIncentive(rebate, product, volume);

            return result;
        }
    }
}

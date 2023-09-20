using Smartwyre.DeveloperTest.Core.Enums;
using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Infrastructure.Factory.Implementation
{
    public class FixedRateRebateIncentive : IIncentive
    {
        public IncetiveCalculationResult CalculateIncentive(Rebate rebate, Product product, decimal volume)
        {
            var result = new IncetiveCalculationResult();

            if ((rebate.Percentage == 0 || product.Price == 0 || volume == 0) || (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate)))
            {
                result.Amount = 0m;
                result.Success = false;
            }
            else
            {
                result.Amount += product.Price * rebate.Percentage * volume;
                result.Success = true;
            }

            return result;
        }
    }

    public class AmountPerUomIncentive : IIncentive
    {
        public IncetiveCalculationResult CalculateIncentive(Rebate rebate, Product product, decimal volume)
        {
            var result = new IncetiveCalculationResult();

            if ((rebate.Amount == 0 || volume == 0) || (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)))
            {
                result.Amount = 0m;
                result.Success = false;
            }
            else
            {
                result.Amount += rebate.Amount * volume;
                result.Success = true;
            }

            return result;  
        }
    }

    public class FixedCashAmountIncentive : IIncentive
    {
        public IncetiveCalculationResult CalculateIncentive(Rebate rebate, Product product, decimal volume) => CalculateIncentive(rebate, product);

        public IncetiveCalculationResult CalculateIncentive(Rebate rebate, Product product)
        {
            var result = new IncetiveCalculationResult();
            
            if ((rebate.Amount == 0) || (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount)))
            {
                result.Amount = 0m;
                result.Success = false;
            }
            else
            {
                result.Amount = rebate.Amount;
                result.Success = true;
            }

            return result;
        }
    }
}
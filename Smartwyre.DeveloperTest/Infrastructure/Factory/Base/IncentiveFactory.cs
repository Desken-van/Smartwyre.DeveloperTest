using Smartwyre.DeveloperTest.Core.Enums;
using Smartwyre.DeveloperTest.Infrastructure.Factory.Implementation;
using System;

namespace Smartwyre.DeveloperTest.Infrastructure.Factory.Base
{
    public static class IncentiveFactory
    {
        public static IIncentive CreateIncentive(IncentiveType type)
        {
            switch (type)
            {
                case IncentiveType.FixedRateRebate:
                    return new FixedRateRebateIncentive();

                case IncentiveType.AmountPerUom:
                    return new AmountPerUomIncentive();

                case IncentiveType.FixedCashAmount:
                    return new FixedCashAmountIncentive();

                default:
                    throw new ArgumentException("Unsupported incentive type");
            }
        }
    }
}
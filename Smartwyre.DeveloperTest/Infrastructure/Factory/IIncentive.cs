using Smartwyre.DeveloperTest.Models;

namespace Smartwyre.DeveloperTest.Infrastructure.Factory
{
    public interface IIncentive
    {
        IncetiveCalculationResult CalculateIncentive(Rebate rebate, Product product, decimal volume);
    }
}

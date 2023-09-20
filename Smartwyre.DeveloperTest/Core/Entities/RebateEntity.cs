using Smartwyre.DeveloperTest.Core.Enums;

namespace Smartwyre.DeveloperTest.Core.Entities
{
    public class RebateEntity
    {
        public string Identifier { get; set; }
        public IncentiveType Incentive { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}

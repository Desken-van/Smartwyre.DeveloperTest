using Smartwyre.DeveloperTest.Core.Enums;

namespace Smartwyre.DeveloperTest.Core.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public decimal Price { get; set; }
        public string Uom { get; set; }
        public SupportedIncentiveType SupportedIncentives { get; set; }
    }
}

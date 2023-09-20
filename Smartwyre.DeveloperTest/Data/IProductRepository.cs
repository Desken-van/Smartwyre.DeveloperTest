using Smartwyre.DeveloperTest.Models;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdentifierAsync(string identifier);
    }
}
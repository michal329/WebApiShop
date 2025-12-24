using Repositories.Models;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
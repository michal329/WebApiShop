
using Repositories.Models;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order newOrder);
        Task<Order> GetOrderById(int id);
    }
}
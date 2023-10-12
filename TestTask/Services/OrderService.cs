using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderService(ApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;
        public async Task<Order> GetOrder() =>
            _applicationDbContext.Orders.OrderByDescending(order => order.Price).First();
        public Task<List<Order>> GetOrders() =>
            Task.FromResult(_applicationDbContext.Orders.Where(order => order.Quantity > 10).ToList());
    }
}

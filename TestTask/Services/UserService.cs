using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserService(ApplicationDbContext applicationDbContext) => 
            _applicationDbContext = applicationDbContext;

        public Task<User> GetUser() =>
            Task.FromResult(_applicationDbContext.Users.OrderByDescending(user => user.Orders.Count).First());

        public Task<List<User>> GetUsers() =>
            Task.FromResult(_applicationDbContext.Users.Where(user => user.Status == Enums.UserStatus.Inactive).ToList());
    }
}

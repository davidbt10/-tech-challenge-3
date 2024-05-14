using EMB.Domain.Enum;
using EMB.Domain.Interfaces;
using EMB.Domain.OrderDomain;
using EMB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMB.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _dbContext;

        public OrderRepository(IConfiguration configuration)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        public void UpdateOrderStatus(Order order, StatusEnum status, string description)
        {
            _dbContext.Orders.Attach(order);

            order.Status = status;
            order.StatusDescription = description;

            _dbContext.SaveChanges();
        }
    }
}

using EMB.Domain.Interfaces;
using EMB.Domain.OrderDomain;
using EMB.Infrastructure.Context;
using EMB.Infrastructure.Providers;
using System.Text;
using System.Text.Json;

namespace EMB.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RabbitMQClient _rabbitMQClient;
        private readonly ApplicationDbContext _dbContext;
        private readonly string _queueName = "orders";

        public OrderRepository(RabbitMQClient rabbitMQClient, ApplicationDbContext dbContext)
        {
            _rabbitMQClient = rabbitMQClient;
            _dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public Order? GetOrderById(int orderId)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == orderId);
        }

        public Order? GetOrderByUser(int accountId)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.AccountId == accountId);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }

        public void SendOrderToQueue(Order order)
        {
            using (var connection = _rabbitMQClient.Connect())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var message = JsonSerializer.Serialize(order);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: _queueName,
                    mandatory: false,
                    basicProperties: null,
                    body: body);
            }
        }
    }
}

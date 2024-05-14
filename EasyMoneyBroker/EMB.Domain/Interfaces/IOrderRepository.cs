using EMB.Domain.OrderDomain;

namespace EMB.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void SendOrderToQueue(Order order);
        Order? GetOrderById(int orderId);
        Order? GetOrderByUser(int accountId);
        IEnumerable<Order> GetAll();
    }
}

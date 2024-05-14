using EMB.Domain.Enum;
using EMB.Domain.OrderDomain;

namespace EMB.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void UpdateOrderStatus(Order order, StatusEnum status, string description);
    }
}

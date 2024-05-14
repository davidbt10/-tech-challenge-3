using EMB.Application.DTOs;

namespace EMB.Application.Interfaces.Order
{
    public interface IOrderService
    {
        int BuyStock(OrderDto order);
    }
}

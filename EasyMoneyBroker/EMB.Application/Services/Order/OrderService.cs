using EMB.Application.DTOs;
using EMB.Application.Interfaces.Order;
using EMB.Domain.Interfaces;

namespace EMB.Application.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IStockRepository stockRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
            _userRepository = userRepository;
        }

        public int BuyStock(OrderDto req)
        {
            var stock = _stockRepository.GetByCode(req.Ticker);

            if (stock == null)
                throw new ArgumentException("O código de ação informado, não existe.");

            var user = _userRepository.GetByCode(req.ClientId);

            if (user == null)
                throw new ArgumentException("O usuário informado, não está cadastrado na plataforma.");


            var order = new Domain.OrderDomain.Order(user.UserID, stock.StockID, req.Quantity, stock.CurrentPrice);

            _orderRepository.CreateOrder(order);
            _orderRepository.SendOrderToQueue(order);

            return order.Id;
        }
    }
}

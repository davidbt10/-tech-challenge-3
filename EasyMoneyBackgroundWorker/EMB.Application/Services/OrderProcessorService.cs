using EMB.Application.Interfaces;
using EMB.Domain.Enum;
using EMB.Domain.Interfaces;
using EMB.Domain.OrderDomain;
using System.Text.Json;

namespace EMB.Application.Services
{
    public class OrderProcessorService : IOrderProcessorService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderProcessorService(IAccountRepository accountRepository, IOrderRepository orderRepository)
        {
            _accountRepository = accountRepository;
            _orderRepository = orderRepository;
        }

        public void ProcessPurchaseOrders(string message)
        {
            var order = JsonSerializer.Deserialize<Order>(message);

            var account = _accountRepository.GetByUserId(order.AccountId);

            if (account.ValidateUserBalance(order.TotalPrice))
            {
                account.SubtractBalance(order.TotalPrice);

                _accountRepository.Update(account);
                _orderRepository.UpdateOrderStatus(order, StatusEnum.Processed, "Ordem processada com sucesso.");
            }
            else
                _orderRepository.UpdateOrderStatus(order, StatusEnum.Rejected, "Saldo insulficiente.");
        }
    }
}

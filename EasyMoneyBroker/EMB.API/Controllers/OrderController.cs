using EMB.Application.DTOs;
using EMB.Application.Interfaces.Order;
using EMB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMB.API.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderService orderService, IOrderRepository orderRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult BuyOrder(OrderDto req)
        {
            req.Validate();
            var orderId = _orderService.BuyStock(req);

            return Ok($"Ordem {orderId} criada com sucesso");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderRepository.GetAll());
        }

        [HttpGet]
        [Route("{orderId}")]
        public IActionResult GetById([FromRoute] int orderId)
        {
            return Ok(_orderRepository.GetOrderById(orderId));
        }

        [HttpGet]
        [Route("/user/{userId}")]
        public IActionResult GetByUser([FromRoute] int userId)
        {
            return Ok(_orderRepository.GetOrderByUser(userId));
        }
    }
}

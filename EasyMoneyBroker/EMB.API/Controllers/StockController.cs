using EMB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMB.API.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {

        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_stockRepository.GetAll());
        }
    }
}

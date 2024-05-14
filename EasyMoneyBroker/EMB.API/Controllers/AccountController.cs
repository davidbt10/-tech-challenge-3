using EMB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMB.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_accountRepository.GetAll());
        }
    }
}

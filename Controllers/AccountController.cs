using IntraNet.Entities;
using IntraNet.Models;
using IntraNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntraNet.Controllers
{
    [Route("api/intranet/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]LoginDto dto, CancellationToken cancellationToken)
        {
            string token = await _service.GenerateJwt(dto, cancellationToken);
            return Ok(token);
        }
    }
}

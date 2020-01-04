using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
     
        [HttpPost]
        public IActionResult Post([FromServices] IClienteApplicationService services, ClienteCadastroViewModel model)
        {
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Presentation.Api.Validations;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromServices] IClienteApplicationService clienteApplicationService,
                                  [FromServices] IEnderecoApplicationService enderecoApplicationService, ClienteCadastroViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                clienteApplicationService.Create(model);
                enderecoApplicationService.Create(model.Endereco);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put([FromServices] IClienteApplicationService clienteApplicationService, 
                                 [FromServices] IEnderecoApplicationService enderecoApplicationService, ClienteEdicaoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                clienteApplicationService.Update(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IClienteApplicationService clienteApplicationService, ClienteConsultaViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                clienteApplicationService.Remove(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                var result = clienteApplicationService.Find();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("cpf")]
        public IActionResult Get([FromServices] IClienteApplicationService clienteApplicationService, string nome)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                return Ok(clienteApplicationService.Find(nome));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IClienteApplicationService clienteApplicationService, Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                return Ok(clienteApplicationService.Find(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

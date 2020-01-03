using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Application.Services;
using Projeto.Presentation.Api.Validations;
using System;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] IClienteApplicationService services, ClienteCadastroViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                services.Create(model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put([FromServices] IClienteApplicationService services, ClienteEdicaoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                services.Update(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IClienteApplicationService services, ClienteConsultaViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                services.Remove(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromServices] IClienteApplicationService services)
        {
            try
            {
                return Ok(services.Find());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{nome}")]
        public IActionResult Get([FromServices] IClienteApplicationService services, string nome)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                return Ok(services.Find(nome));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IClienteApplicationService services, Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelStateValidation.GetErrors(ModelState));

            try
            {
                return Ok(services.Find(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
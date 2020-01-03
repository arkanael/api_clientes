using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class ClienteEdicaoViewModel : ClienteCadastroViewModel
    {
        [Required(ErrorMessage = "Preencha o identificador do cliente")]
        public Guid IdCliente { get; set; }
    }
}

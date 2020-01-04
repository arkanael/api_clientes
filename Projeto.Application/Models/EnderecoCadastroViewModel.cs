using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class EnderecoCadastroViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(40, ErrorMessage = "Máximo {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(40, ErrorMessage = "Máximo {0} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(40, ErrorMessage = "Máximo {0} caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o id do cliente")]
        public Guid IdCliente { get; set; }


    }
}

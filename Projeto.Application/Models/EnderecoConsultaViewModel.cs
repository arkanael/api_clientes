using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class EnderecoConsultaViewModel
    {
        public Guid IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}

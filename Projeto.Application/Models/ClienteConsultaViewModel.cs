using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class ClienteConsultaViewModel
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoConsultaViewModel Endereco { get; set; } = new EnderecoConsultaViewModel();
    }
}

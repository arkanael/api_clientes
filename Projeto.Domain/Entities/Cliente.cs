﻿using Projeto.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Projeto.Domain.Entities
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
      
        public string Nome { get; set; }
        
        public string Cpf { get; set; }
        
        public int Idade { get; set; }
        
        public DateTime DataNascimento { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}

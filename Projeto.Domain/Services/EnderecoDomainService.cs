using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{    
    public class EnderecoDomainService : BaseDomainService<Endereco>, IEnderecoDomainService
    {
        public EnderecoDomainService(IEnderecoRepository repository) : base(repository)
        {
        }
    }
}

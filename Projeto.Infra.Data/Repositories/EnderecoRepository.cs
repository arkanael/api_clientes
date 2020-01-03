
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context) : base(context)
        {

        }
    }
}

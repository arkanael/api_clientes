using Projeto.Application.Models;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Contracts
{
    public interface IEnderecoApplicationService: IDisposable
    {
        void Create(EnderecoCadastroViewModel model);
        void Update(EnderecoEdicaoViewModel model);
        void Delete(EnderecoConsultaViewModel model);
        IEnumerable<EnderecoConsultaViewModel> Find();
        IEnumerable<EnderecoConsultaViewModel> Find(string nome);
        EnderecoConsultaViewModel Find(Guid id);


    }
}

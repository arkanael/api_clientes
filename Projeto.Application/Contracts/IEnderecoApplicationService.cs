using Projeto.Application.Models;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Contracts
{
    public interface IEnderecoApplicationService: IDisposable
    {
        void Create(ClienteCadastroViewModel model);
        void Update(ClienteEdicaoViewModel model);
        void Delete(ClienteConsultaViewModel model);
        IEnumerable<ClienteConsultaViewModel> Find();
        IEnumerable<ClienteConsultaViewModel> Find(string nome);
        ClienteConsultaViewModel Find(Guid id);


    }
}

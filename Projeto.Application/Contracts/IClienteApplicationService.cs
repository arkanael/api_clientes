using Projeto.Application.Models;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Contracts
{
    public interface IClienteApplicationService: IDisposable
    {
        void Create(ClienteCadastroViewModel model);
        void Update(ClienteCadastroViewModel model);
        void Remove(ClienteConsultaViewModel model);
        IEnumerable<ClienteConsultaViewModel> Find();
        IEnumerable<ClienteConsultaViewModel> Find(string nome);
        ClienteConsultaViewModel Find(Guid id);

    }
}

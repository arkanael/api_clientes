using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteDomainService service;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IClienteDomainService service, IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
        }

        public void Create(ClienteCadastroViewModel model)
        {
            service.Insert(_mapper.Map<Cliente>(model));
        }

        public void Update(ClienteCadastroViewModel model)
        {
            service.Update(_mapper.Map<Cliente>(model));
        }

        public void Remove(ClienteConsultaViewModel model)
        {
            service.Delete(_mapper.Map<Cliente>(model));
        }

        public IEnumerable<ClienteConsultaViewModel> Find()
        {
            return _mapper.Map<List<ClienteConsultaViewModel>>(service.Find());
        }

        public IEnumerable<ClienteConsultaViewModel> Find(string nome)
        {
            return _mapper.Map<List<ClienteConsultaViewModel>>(service.Find( x => x.Nome.Contains(nome)));
        }

        public ClienteConsultaViewModel Find(Guid id)
        {
            return _mapper.Map<ClienteConsultaViewModel>(service.Find(id));
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}

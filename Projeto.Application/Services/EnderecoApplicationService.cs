using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Services
{
    public class EnderecoApplicationService : IEnderecoApplicationService
    {
        private readonly IEnderecoDomainService service;
        private readonly IMapper _mapper;

        public EnderecoApplicationService(IEnderecoDomainService service, IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
        }

        public void Create(EnderecoCadastroViewModel model)
        {
            service.Insert(_mapper.Map<Endereco>(model));
        }

        public void Update(EnderecoEdicaoViewModel model)
        {
            service.Update(_mapper.Map<Endereco>(model));
        }

        public void Delete(EnderecoConsultaViewModel model)
        {
            service.Delete(_mapper.Map<Endereco>(model));
        }

        public IEnumerable<EnderecoConsultaViewModel> Find()
        {
            return _mapper.Map<List<EnderecoConsultaViewModel>>(service.Find());
        }

        public IEnumerable<EnderecoConsultaViewModel> Find(string nome)
        {
            return _mapper.Map<List<EnderecoConsultaViewModel>>(service.Find(x => x.Estado.Contains(nome)));
        }

        public EnderecoConsultaViewModel Find(Guid id)
        {
            return _mapper.Map<EnderecoConsultaViewModel>(service.Find(id));
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}

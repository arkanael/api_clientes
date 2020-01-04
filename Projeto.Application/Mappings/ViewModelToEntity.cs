using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Mappings
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<ClienteCadastroViewModel, Cliente>()
               .AfterMap((src, dest) => dest.IdCliente = Guid.NewGuid())
               .AfterMap((src, dest) => src.Endereco.IdCliente = dest.IdCliente);
               

            CreateMap<ClienteEdicaoViewModel, Cliente>();

            CreateMap<ClienteConsultaViewModel, Cliente>();

            CreateMap<EnderecoCadastroViewModel, Endereco>()
               .AfterMap((src, dest) => dest.IdEndereco = Guid.NewGuid());

        }
    }
}

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
               .AfterMap((src, dest) => dest.IdCliente = Guid.NewGuid());

            CreateMap<ClienteEdicaoViewModel, Cliente>();

            CreateMap<ClienteConsultaViewModel, Cliente>();



        }
    }
}

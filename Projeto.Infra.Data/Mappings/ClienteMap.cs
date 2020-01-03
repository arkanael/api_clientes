using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.IdCliente);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(175)")
                .IsRequired();

            builder.Property(x => x.Cpf)
               .HasColumnName("Cpf")
               .HasColumnType("varchar(11")
               .IsRequired();

            builder.Property(x => x.Idade)
             .HasColumnName("Idade")
             .IsRequired();

            builder.Property(x => x.DataNascimento)
            .HasColumnName("DataNascimento")
            .IsRequired();
        }
    }
}

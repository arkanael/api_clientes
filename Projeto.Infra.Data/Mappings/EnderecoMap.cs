using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.IdEndereco);

            builder.Property(x => x.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(175)")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(55)")
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.IdCliente)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System.IO;

namespace Projeto.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();
             
            optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}

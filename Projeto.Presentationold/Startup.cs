using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Concurrent;
using System.Configuration;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IClienteApplicationService, ClienteApplicationService>();

            services.AddSingleton<IClienteDomainService, ClienteDomainService>();
            services.AddSingleton<IEnderecoDomainService, EnderecoDomainService>();

            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<IEnderecoRepository, EnderecoRepository>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            #region Configuração do Swagger

            services.AddSwaggerGen(
                  swagger =>
                  {
                      swagger.SwaggerDoc("v1",
                          new Info
                          {
                              Title = "Sistema Asp.Net Web API - Cadastro de Clientes",
                              Version = "v1",
                              Description = "Desafio - Vanessa G Carvalho",
                              Contact = new Contact
                              {
                                  Name = "VANESSA G CARVALHO",
                                  Url = "http://www.vanessagcarvalho.com.br",
                                  Email = "vanessagc.info@gmail.com"
                              }
                          });
                  }
              );

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Configuração do Swagger

            app.UseSwagger();
            app.UseSwaggerUI(
                    swagger =>
                    {
                        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                    }
                );

            #endregion

            app.UseMvc();
        }
    }
}

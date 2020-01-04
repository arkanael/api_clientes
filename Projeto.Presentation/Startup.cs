using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IEnderecoApplicationService, EnderecoApplicationService>();

            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IEnderecoDomainService, EnderecoDomainService>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        

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

            services.AddCors(c => c.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                    swagger =>
                    {
                        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                    }
                );
        }
    }
}

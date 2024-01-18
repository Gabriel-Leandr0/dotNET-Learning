using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.Application.Interfaces;
using ProEventos.Application.Services;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //  configurar os serviços que serão utilizados pela aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            //Realiza configuração do banco de dados
            //Default = appsettings.Development
            services.AddDbContext<ProEventosContext>(
                context  => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            //Configura o retorno do JSON
            services.AddControllers()

            //Ignora o loop de referência, necesario instalar o pacote NewtonsoftJson (Microsoft.aspnetcore.mvc.newtonsoftjson)
                .AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            
            //Configura a injeção de dependência
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoPersist, EventoPersist>();
            services.AddScoped<IGeralPersist, GeralPersist>();



            //Permite que qualquer aplicação acesse a API
            services.AddCors();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            //app.UseHttpsRedirection() redireciona para https
            app.UseHttpsRedirection();

            //Define o padrão de rota da API
            app.UseRouting();

            //Define o padrão de autorização da API
            app.UseAuthorization();

            //Permite que qualquer aplicação acesse a API
            app.UseCors(cors => cors.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APICadastroUsuario.Configuracoes
{
    public static class SwaggerConfiguracoes
    {
        public static void AddSwaggerConfiguracoes(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cadastro de Usuários",
                    Version = "v1",
                    Description = "API desenvolvida para avaliação técnica. Permite inserir, editar, buscar e excluir usuários de uma base de dados.",
                    Contact = new OpenApiContact
                    {
                        Name = "Manoel Geraldo",
                        Email = "manoelgeraldo.com@gmail.com",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "Infra.Shared.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguracoes(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroUsuario - v1"));
        }
    }
}

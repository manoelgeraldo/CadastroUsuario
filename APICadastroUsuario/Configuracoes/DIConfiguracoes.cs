using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICadastroUsuario.Configuracoes
{
    public static class DIConfiguracoes
    {
        public static void AddDIConfiguracoes(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

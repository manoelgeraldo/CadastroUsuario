using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

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

using Microsoft.Extensions.DependencyInjection;
using Service.Mappings;

namespace APICadastroUsuario.Configuracoes
{
    public static class AutoMapperConfiguracoes
    {
        public static void AddAutoMapperConfiguracoes(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UsuarioMappingProfile));
        }
    }
}

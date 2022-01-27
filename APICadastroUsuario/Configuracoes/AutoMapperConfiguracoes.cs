using Microsoft.Extensions.DependencyInjection;
using Service.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

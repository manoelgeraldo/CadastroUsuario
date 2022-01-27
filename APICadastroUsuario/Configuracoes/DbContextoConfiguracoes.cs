using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APICadastroUsuario.Configuracoes
{
    public static class DbContextoConfiguracoes
    {
        public static void AddDbContextoConfiguracoes(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DbContexto>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
        }
    }
}

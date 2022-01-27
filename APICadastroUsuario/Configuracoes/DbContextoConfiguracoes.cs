using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

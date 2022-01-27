using Shared.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<ExibirUsuario>> BuscarTodosUsuariosAsync();

        Task<ExibirUsuario> BuscarUsuarioPorIdAsync(int id);

        Task<ExibirUsuario> AdicionarUsuarioAsync(NovoUsuario usuario);

        Task<ExibirUsuario> AlterarUsuarioAsync(AlterarUsuario alterarUsuario);

        Task<ExibirUsuario> ExcluirUsuario(int id);
    }
}

using Shared.ViewModels.Usuario;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<ExibirUsuario>> ExibirUsuariosAsync();

        Task<ExibirUsuario> ObterUsuarioPorIdAsync(int id);

        Task<ExibirUsuario> AdicionarUsuarioAsync(NovoUsuario usuario);

        Task<ExibirUsuario> AlterarUsuarioAsync(AlterarUsuario alterarUsuario);

        Task<ExibirUsuario> ExcluirUsuario(int id);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.ViewModels.Usuario;
using System.Threading.Tasks;

namespace APICadastroUsuario.Configuracoes.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService manager;

        public UsuariosController(IUsuarioService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Exibe uma lista com todos os usuários.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ExibirUsuario), StatusCodes.Status200OK)]
        [Route("lista-de-usuarios")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await manager.ExibirUsuariosAsync().ConfigureAwait(false);
            return Ok(usuarios);
        }

        /// <summary>
        /// Exibe um Registro consultado pelo id
        /// </summary>
        /// <param name="id" example="2">Registro</param>
        [HttpGet("buscar-usuario/{id}")]
        [ProducesResponseType(typeof(AlterarUsuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await manager.ObterUsuarioPorIdAsync(id).ConfigureAwait(false);

            if (usuario is null)
            {
                return NotFound("Usuário não existe na base de dados!");
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        [HttpPost]
        [Route("novo-usuario")]
        public async Task<IActionResult> Post(NovoUsuario novoUsuario)
        {
            var usuarioInserido = await manager.AdicionarUsuarioAsync(novoUsuario).ConfigureAwait(false);

            if (usuarioInserido != null)
            {
                return CreatedAtAction(nameof(Get), new { id = usuarioInserido.Id }, usuarioInserido);
            }

            return new ObjectResult("Usuário já existe na base!") { StatusCode = 403 };
        }

        /// <summary>
        /// Altera um usuário existente.
        /// </summary>
        [HttpPut]
        [Route("alterar-usuario")]
        public async Task<IActionResult> Put(AlterarUsuario alterarUsuario)
        {
            var usuarioAlterado = await manager.AlterarUsuarioAsync(alterarUsuario).ConfigureAwait(false);
            if (usuarioAlterado is null)
            {
                return NotFound("Usuário não existe na base de dados!");
            }
            return Ok("Usuário alterado com sucesso!");
        }

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <remarks>Ao excluir um usuário o mesmo será removido permanentemente da base!</remarks>
        [HttpDelete("excluir-usuario/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioExcluido = await manager.ExcluirUsuario(id).ConfigureAwait(false);
            if (usuarioExcluido is null)
            {
                return NotFound("Usuário não existe na base de dados!");
            }
            return Ok("Usuário Excluído com sucesso!");
        }
    }
}

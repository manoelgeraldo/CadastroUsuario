namespace Shared.ViewModels.Usuario
{
    public class ExibirUsuario : NovoUsuario
    {
        /// <summary>
        /// Id do usuario.
        /// </summary>
        /// <example>01</example>.
        public int Id { get; set; }

        /// <summary>
        /// Status do usuário.
        /// </summary>
        /// <example>true</example>.
        public bool Ativo { get; set; }
    }
}

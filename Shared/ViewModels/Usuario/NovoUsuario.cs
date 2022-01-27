using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels.Usuario
{
    public class NovoUsuario
    {
        /// <summary>
        /// Nome do usuario.
        /// </summary>
        /// <example>Airton Senna</example>.
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento.
        /// </summary>
        /// <example>1960-03-21</example>.
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Email do usuario.
        /// </summary>
        /// <example>airtonsenna@gmail.com</example>.
        public string Email { get; set; }

        /// <summary>
        /// Email do usuario.
        /// </summary>
        /// <example>81912345678</example>.
        public string Telefone { get; set; }

        /// <summary>
        /// Sigla do Estado.
        /// </summary>
        /// <example>PE</example>.
        public string UF { get; set; }

        /// <summary>
        /// Munícipio.
        /// </summary>
        /// <example>Olinda</example>.
        public string Municipio { get; set; }

        /// <summary>
        /// Senha do usuario.
        /// </summary>
        /// <example>123456</example>.
        public string Senha { get; set; }
    }
}

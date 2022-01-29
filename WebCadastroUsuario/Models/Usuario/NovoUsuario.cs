using System.ComponentModel.DataAnnotations;

namespace WebCadastroUsuario.Models
{
    public class NovoUsuario
    {
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}

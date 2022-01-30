using System.ComponentModel.DataAnnotations;

namespace WebCadastroUsuario.Models
{
    public class NovoUsuario
    {
        [Required(ErrorMessage = "É obrigatório!")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "É obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "É obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É obrigatório!")]
        public string UF { get; set; }

        [Required(ErrorMessage = "É obrigatório!")]
        public string Municipio { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "É obrigatório!")]
        public string Senha { get; set; }
    }
}

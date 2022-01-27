using System;

namespace Domain;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string UF { get; set; }
    public string Municipio { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; } = true;
}

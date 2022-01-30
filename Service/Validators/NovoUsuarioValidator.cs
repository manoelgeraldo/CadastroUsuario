using FluentValidation;
using Shared.ViewModels.Usuario;

namespace Service.Validators
{
    public class NovoUsuarioValidator : AbstractValidator<NovoUsuario>
    {
        public NovoUsuarioValidator()
        {
            RuleFor(x => x.Nome).Length(3, 50).NotEmpty().NotNull().WithMessage("O nome deve ser informado!");
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull().WithMessage("A data de nascimento deve ser informado!");
            RuleFor(x => x.Telefone).MinimumLength(11).MaximumLength(15).NotEmpty().NotNull().WithMessage("O telefone deve ser informado!");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("O e-mail deve ser informado!");
            RuleFor(x => x.UF).MinimumLength(2).MaximumLength(2).NotEmpty().NotNull().WithMessage("O estado deve ser informado!");
            RuleFor(x => x.Municipio).MaximumLength(30).NotEmpty().NotNull().WithMessage("O município deve ser informado!");
            RuleFor(x => x.Senha).Length(6, 10).NotEmpty().NotNull().WithMessage("A senha deve ter entre 6 a 10 caracteres!");
        }
    }
}

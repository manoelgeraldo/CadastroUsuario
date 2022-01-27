using Domain;
using FluentValidation;

namespace Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).Length(50).NotEmpty().NotNull().WithMessage("Informe o Nome!");
            RuleFor(x => x.Senha).Length(10).NotEmpty().NotNull().WithMessage("Informe a Senha!");
        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("date");
            builder.Property(x => x.Email).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(11);
            builder.Property(x => x.UF).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Municipio).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(10).IsRequired();
        }
    }
}
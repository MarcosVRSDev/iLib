using ILib.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ILib.Infra.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Uid)
                .IsRequired()
                .HasColumnName("Usr_Uid");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Usr_Nome");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("Usr_Email");
        }
    }
}

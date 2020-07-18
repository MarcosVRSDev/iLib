using ILib.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ILib.Infra.Mapeamento
{
    public class LivroMapeamento : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnName("Liv_Codigo")
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnName("Liv_Titulo")
                .HasColumnType("varchar(255)");

            builder.Property(p => p.FotoUrl)
                .IsRequired()
                .HasColumnName("Liv_Foto_Url")
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Autor)
                .HasColumnName("Liv_Autor")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Editora)
                .HasColumnName("Liv_Editora")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Emprestado)
                .HasColumnName("Liv_Emprestado")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(p => p.Estado)
                .HasColumnName("Liv_Estado")
                .HasColumnType("integer");

            builder.Property(p => p.Observacoes)
                 .HasColumnName("Liv_Observacoes")
                 .HasColumnType("varchar(255)");
        }
    }
}

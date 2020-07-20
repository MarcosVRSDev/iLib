using ILib.Dominio.Entidades;
using ILib.Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ILib.Infra.Mapeamento
{
    public class EmprestimoMapeamento : IEntityTypeConfiguration<Emprestimo>

    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataEmprestimo)
                .HasColumnName("Emp_Data_Emprestimo")
                .HasColumnType("timestamp");

            builder.Property(p => p.DataPrevDevolucao)
                .HasColumnName("Emp_Data_Prev_Devolucao")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(p => p.DataDevolucao)
                .HasColumnName("Emp_Data_Devolucao")
                .HasColumnType("timestamp");

            builder.Property(p => p.LivroId)
                .HasColumnName("Emp_Livro_Id")
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(p => p.Observacao)
                .HasColumnName("Emp_Observacao")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Status)
                .HasColumnName("Emp_Status")
                .HasDefaultValue(EStatusEmprestimo.PENDENTE)
                .HasColumnType("integer");

            builder.Property(p => p.UsuarioId)
                .HasColumnName("Emp_Usuario_Id")
                .IsRequired()
                .HasColumnType("varchar(36)");
        }
    }
}

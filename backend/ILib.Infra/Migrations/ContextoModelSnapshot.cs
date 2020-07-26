﻿// <auto-generated />
using System;
using ILib.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ILib.Infra.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ILib.Dominio.Entidades.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnName("Emp_Data_Devolucao")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnName("Emp_Data_Emprestimo")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DataPrevDevolucao")
                        .IsRequired()
                        .HasColumnName("Emp_Data_Prev_Devolucao")
                        .HasColumnType("timestamp");

                    b.Property<int>("LivroId")
                        .HasColumnName("Emp_Livro_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Observacao")
                        .HasColumnName("Emp_Observacao")
                        .HasColumnType("varchar(60)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Emp_Status")
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnName("Emp_Usuario_Id")
                        .HasColumnType("varchar(36)");

                    b.Property<int?>("UsuarioId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("ILib.Dominio.Entidades.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Autor")
                        .HasColumnName("Liv_Autor")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("Liv_Codigo")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Editora")
                        .HasColumnName("Liv_Editora")
                        .HasColumnType("varchar(80)");

                    b.Property<bool>("Emprestado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Liv_Emprestado")
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("Estado")
                        .HasColumnName("Liv_Estado")
                        .HasColumnType("integer");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnName("Liv_Foto_Url")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Observacoes")
                        .HasColumnName("Liv_Observacoes")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("Liv_Titulo")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("ILib.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ILib.Dominio.Entidades.Emprestimo", b =>
                {
                    b.HasOne("ILib.Dominio.Entidades.Livro", "Livro")
                        .WithMany("Emprestimos")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILib.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1");
                });
#pragma warning restore 612, 618
        }
    }
}

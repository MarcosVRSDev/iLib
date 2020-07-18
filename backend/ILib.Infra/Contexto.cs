using ILib.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ILib.Infra
{
    public class Contexto : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);
        }

    }
}

using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Infra.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly Contexto _contexto;

        public LivroRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Livro> Criar(Livro livro)
        {
            _contexto.Livros.Add(livro);
            await _contexto.SaveChangesAsync(default);

            return livro;
        }

        public async Task<Livro> Editar(Livro livro)
        {
            var obj = await _contexto.Livros.FindAsync(livro.Id);

            obj.Autor = livro.Autor;
            obj.Codigo = livro.Codigo;
            obj.Editora = livro.Editora;
            obj.Emprestado = livro.Emprestado;
            obj.Estado = livro.Estado;
            obj.FotoUrl = livro.FotoUrl;
            obj.Observacoes = livro.Observacoes;
            obj.Titulo = livro.Titulo;

            await _contexto.SaveChangesAsync(default);

            return livro;
        }

        public async Task<bool> Remover(int idLivro)
        {
            var obj = await _contexto.Livros.FindAsync(idLivro);
            _contexto.Remove(obj);
            await _contexto.SaveChangesAsync(default);

            return true;
        }

        public async Task<Livro> SelecionarPorId(int idLivro)
        {
            return await _contexto.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == idLivro);
        }

        public async Task<ICollection<Livro>> SelecionarTodos()
        {
            return await _contexto.Livros.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }
    }
}

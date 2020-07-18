using ILib.Core.Dados;
using ILib.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Dominio.Repositorio
{
    public interface ILivroRepositorio : IRepositorio<Livro>
    {
        Task<Livro> Criar(Livro livro);
        Task<Livro> Editar(Livro livro);
        Task<bool> Remover(int idLivro);
        Task<ICollection<Livro>> SelecionarTodos();
        Task<Livro> SelecionarPorId(int idLivro);

    }
}

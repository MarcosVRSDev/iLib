using ILib.Core.Dados;
using ILib.Dominio.Entidades;
using ILib.Dominio.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Dominio.Repositorio
{
    public interface IEmprestimoRepositorio : IRepositorio<Emprestimo>
    {
        Task<Emprestimo> Criar(Emprestimo emprestimo);
        Task<Emprestimo> Editar(Emprestimo emprestimo);
        Task<ICollection<Emprestimo>> SelecionarTodos();
        Task<Emprestimo> SelecionarPorId(int emprestimo);
        Task<Emprestimo> SelecionarPorLivroIdEmprestado(int livro);
        Task<ICollection<Emprestimo>> SelecionarPorStatus(EStatusEmprestimo eStatus);

    }
}

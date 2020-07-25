using ILib.Dominio.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Emprestimos
{
    public interface IEmprestimoServico
    {
        Task<EmprestimoViewModel> Criar(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> Editar(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> SelecionarPorId(int IdEmprestimo);
        Task<ICollection<EmprestimoViewModel>> SelecionarTodos();
        Task<ICollection<EmprestimoViewModel>> SelecionarPorStatus(int eStatus);
        Task<EmprestimoViewModel> ConfirmaEmprestimo(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> CancelaEmprestimo(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> RealizaDevolucao(EmprestimoViewModel emprestimo);
        bool Sucesso();
        List<string> Erros { get; }

    }
}

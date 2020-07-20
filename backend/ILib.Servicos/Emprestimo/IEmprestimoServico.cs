﻿using ILib.Dominio.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Emprestimo
{
    public interface IEmprestimoServico
    {
        Task<EmprestimoViewModel> Criar(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> Editar(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> SelecionarPorId(int IdEmprestimo);
        Task<ICollection<EmprestimoViewModel>> SelecionarTodos();
        Task<ICollection<EmprestimoViewModel>> SelecionarPorStatus(EStatusEmprestimo eStatus);
        Task<EmprestimoViewModel> ConfirmaEmprestimo(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> CancelaEmprestimo(EmprestimoViewModel emprestimo);
        Task<EmprestimoViewModel> RealizaDevolucao(EmprestimoViewModel emprestimo);

    }
}

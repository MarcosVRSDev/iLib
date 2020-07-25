using ILib.Dominio.Entidades;
using ILib.Dominio.Enums;
using ILib.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILib.Infra.Repositorio
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly Contexto _contexto;

        public EmprestimoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Emprestimo> Criar(Emprestimo emprestimo)
        {
            _contexto.Emprestimos.Add(emprestimo);
            await _contexto.SaveChangesAsync();
            return emprestimo;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<Emprestimo> Editar(Emprestimo emprestimo)
        {
            _contexto.Entry(emprestimo).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<Emprestimo> SelecionarPorId(int idEmprestimo)
        {
            return await _contexto.Emprestimos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idEmprestimo);
        }

        public async Task<ICollection<Emprestimo>> SelecionarPorStatus(EStatusEmprestimo eStatus)
        {
            return await _contexto.Emprestimos.AsNoTracking().Where(x => x.Status == eStatus).ToListAsync();
        }

        public async Task<ICollection<Emprestimo>> SelecionarTodos()
        {
            return await _contexto.Emprestimos.AsNoTracking().ToListAsync();
        }
    }
}

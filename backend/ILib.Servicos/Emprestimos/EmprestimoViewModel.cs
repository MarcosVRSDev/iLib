using ILib.Core.DominioObjetos;
using ILib.Dominio.Entidades;
using ILib.Servicos.Livros;
using System;

namespace ILib.Servicos.Emprestimos
{
    public class EmprestimoViewModel : ViewModel
    {
        public int LivroId { get; set; }
        public LivroViewModel Livro { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Observacao { get; set; }
        public int Status { get; set; }
    }
}

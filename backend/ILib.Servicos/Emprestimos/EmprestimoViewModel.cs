using ILib.Dominio.Entidades;
using System;

namespace ILib.Servicos.Emprestimos
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }
        public int LivroId { get; set; }

        public string UsuarioId { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataPrevDevolucao { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public string Observacao { get; set; }

        public int Status { get; set; }
    }
}

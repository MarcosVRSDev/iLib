using ILib.Core;
using ILib.Dominio.Enums;
using System;

namespace ILib.Dominio.Entidades
{
    public class Emprestimo : Entidade
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public string UsuarioId { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataPrevDevolucao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public string Observacao { get; set; }

        public EStatusEmprestimo Status { get; set; } 
    }
}

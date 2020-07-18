using ILib.Dominio.Enums;
using System;

namespace ILib.Dominio.Entidades
{
    public class Emprestimo
    {
        public int LivroId { get; set; }

        public string UsuarioID { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataPrevDevolucao { get; set; }

        public DateTime Datadevolucao { get; set; }

        public string Observacao { get; set; }

        public EStatusEmprestimo Status { get; set; } 
    }
}

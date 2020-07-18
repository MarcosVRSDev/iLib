using ILib.Core;
using ILib.Dominio.Enums;

namespace ILib.Dominio.Entidades
{
    public class Livro : Entidade
    {
        public string Codigo { get; set; } //DEV-01 //FIN-01
        public string FotoUrl { get; set; }

        public string Descricao { get; set; }

        public bool Emprestado { get; set; }

        public EEstadoLivro Estado { get; set; }

        public string Observacoes { get; set; }

    }
}

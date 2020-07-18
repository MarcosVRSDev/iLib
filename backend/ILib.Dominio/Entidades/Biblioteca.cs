using ILib.Core;

namespace ILib.Dominio.Entidades
{
    public class Biblioteca : Entidade
    {
        public int LivroId { get; set; }

        public int QtdLivro { get; set; }

        //Exclusivo do Entity
        public Livro Livro { get; set; }
    }
}

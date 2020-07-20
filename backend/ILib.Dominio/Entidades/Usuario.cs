using ILib.Core;

namespace ILib.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

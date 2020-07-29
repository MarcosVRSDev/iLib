using ILib.Core.DominioObjetos;
using ILib.Dominio.Entidades;
using System.Collections.Generic;

namespace ILib.Servicos.Usuarios
{
    public class UsuarioViewModel : ViewModel
    {
        public string Uid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}

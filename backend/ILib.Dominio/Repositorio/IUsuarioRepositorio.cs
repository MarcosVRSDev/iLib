using ILib.Core.Dados;
using ILib.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Dominio.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<ICollection<Usuario>> SelecionarTodos();
    }
}

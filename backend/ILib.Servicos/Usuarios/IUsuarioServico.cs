using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Usuarios
{
    public interface IUsuarioServico
    {
        Task<UsuarioViewModel> CriarUsuario(UsuarioViewModel usuario);
        Task<ICollection<UsuarioViewModel>> SelecionarTodos();
        bool Sucesso();
    }
}

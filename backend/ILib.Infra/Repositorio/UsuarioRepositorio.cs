using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return usuario;
        }
        public async Task<ICollection<Usuario>> SelecionarTodos()
        {
            var usuarios = await _contexto.Usuarios.AsNoTracking().ToListAsync();

            return usuarios;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

    }
}

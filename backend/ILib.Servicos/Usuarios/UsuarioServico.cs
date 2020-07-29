using AutoMapper;
using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Usuarios
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IMapper mapper, IUsuarioRepositorio usuarioRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }


        public async Task<UsuarioViewModel> CriarUsuario(UsuarioViewModel usuario)
        {
            var obj = await _usuarioRepositorio.CriarUsuario(_mapper.Map<Usuario>(usuario));

            return _mapper.Map<UsuarioViewModel>(obj);
        }

        public async Task<ICollection<UsuarioViewModel>> SelecionarTodos()
        {
            var objs =  await _usuarioRepositorio.SelecionarTodos();

           return _mapper.Map<ICollection<UsuarioViewModel>>(objs);
        }

        public bool Sucesso()
        {
            return true;
        }
    }
}

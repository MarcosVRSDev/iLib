using AutoMapper;
using ILib.Dominio.Entidades;
using ILib.Servicos.Emprestimos;
using ILib.Servicos.Livros;
using ILib.Servicos.Usuarios;

namespace ILib.Servicos.AutoMapper
{
    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao()
        {
            CreateMap<LivroViewModel, Livro>().ReverseMap();
            CreateMap<EmprestimoViewModel, Emprestimo>().ReverseMap();
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
        }
    }
}

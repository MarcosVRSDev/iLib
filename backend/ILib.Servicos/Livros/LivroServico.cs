using AutoMapper;
using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Livros
{
    public class LivroServico : ILivroServico
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(IMapper mapper, ILivroRepositorio livroRepositorio)
        {
            _mapper = mapper;
            _livroRepositorio = livroRepositorio;
        }

        public async Task<LivroViewModel> Criar(LivroViewModel livro)
        {
            var obj = await _livroRepositorio.Criar(_mapper.Map<Livro>(livro));
            return _mapper.Map<LivroViewModel>(obj);
        }

        public Task<LivroViewModel> Editar(LivroViewModel livro)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remover(int idLivro)
        {
            throw new System.NotImplementedException();
        }

        public Task<LivroViewModel> SelecionarPorId(int idLivro)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<LivroViewModel>> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _livroRepositorio?.Dispose();
        }
    }
}

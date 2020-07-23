using AutoMapper;
using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using ILib.Servicos.Livros.Validadores.Devolucao;
using ILib.Servicos.Livros.Validadores.Edicao;
using ILib.Servicos.Livros.Validadores.Emprestar;
using ILib.Servicos.Livros.Validadores.Exclusao;
using ILib.Servicos.Livros.Validadores.Inclusao;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILib.Servicos.Livros
{
    public class LivroServico : ILivroServico
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly ILivroValidacaoInclusao _livroValidacaoInclusao;
        private readonly ILivroValidacaoExclusao _livroValidacaoExclusao;
        private readonly ILivroValidacaoEdicao _livroValidacaoEdicao;
        private readonly ILivroValidacaoDevolucao _livroValidacaoDevolucao;
        private readonly ILivroValidacaoEmprestar _livroValidacaoEmprestar;

        public List<string> Erros { get; }

        public LivroServico(
            IMapper mapper, 
            ILivroRepositorio livroRepositorio,
            ILivroValidacaoInclusao livroValidacaoInclusao,
            ILivroValidacaoExclusao livroValidacaoExclusao,
            ILivroValidacaoEdicao livroValidacaoEdicao,
            ILivroValidacaoDevolucao livroValidacaoDevolucao,
            ILivroValidacaoEmprestar livroValidacaoEmprestar)
        {
            _mapper = mapper;
            _livroRepositorio = livroRepositorio;
            _livroValidacaoInclusao = livroValidacaoInclusao;
            _livroValidacaoExclusao = livroValidacaoExclusao;
            _livroValidacaoEdicao = livroValidacaoEdicao;
            _livroValidacaoDevolucao = livroValidacaoDevolucao;
            _livroValidacaoEmprestar = livroValidacaoEmprestar;

            Erros = new List<string>();
        }

        //Commands

        public async Task<LivroViewModel> Criar(LivroViewModel livro)
        {
            var validacoes = _livroValidacaoInclusao.Validar(livro);

            if(validacoes.IsValid)
            {
                var obj = await _livroRepositorio.Criar(_mapper.Map<Livro>(livro));
                return _mapper.Map<LivroViewModel>(obj);
            }

            Erros.AddRange(validacoes.Errors.Select(erro => erro.ErrorMessage).ToList());
            return livro;
        }

        public async Task<LivroViewModel> Editar(LivroViewModel livro)
        {
            var validacoes = _livroValidacaoEdicao.Validar(livro);

            if (validacoes.IsValid)
            {
                var obj = await _livroRepositorio.Editar(_mapper.Map<Livro>(livro));
                return _mapper.Map<LivroViewModel>(obj);
            }

            Erros.AddRange(validacoes.Errors.Select(erro => erro.ErrorMessage).ToList());
            return livro;
        }

        public async Task<bool> Remover(int idLivro)
        {
            var validacoes = _livroValidacaoExclusao.Validar(new LivroViewModel { Id = idLivro });

            if (validacoes.IsValid)
            {
                var obj = await _livroRepositorio.Remover(idLivro);
                return true;
            }

            Erros.AddRange(validacoes.Errors.Select(erro => erro.ErrorMessage).ToList());
            return false;
        }
        public async Task<LivroViewModel> Emprestar(int idLivro)
        {
            var validacoes = _livroValidacaoEmprestar.Validar(new LivroViewModel { Id = idLivro });

            if(validacoes.IsValid)
            {
                var livro = await SelecionarPorId(idLivro);
                livro.Emprestado = true;
                await _livroRepositorio.Editar(_mapper.Map<Livro>(livro));

                return livro;
            }

            Erros.AddRange(validacoes.Errors.Select(erro => erro.ErrorMessage).ToList());

            return new LivroViewModel { Id = idLivro };
        }

        public async Task<LivroViewModel> Devolver(int idLivro)
        {
            var validacoes = _livroValidacaoDevolucao.Validar(new LivroViewModel { Id = idLivro });

            if (validacoes.IsValid)
            {
                var livro = await SelecionarPorId(idLivro);
                livro.Emprestado = false;
                await _livroRepositorio.Editar(_mapper.Map<Livro>(livro));

                return livro;
            }

            Erros.AddRange(validacoes.Errors.Select(erro => erro.ErrorMessage).ToList());

            return new LivroViewModel { Id = idLivro };
        }

        //Queries

        public async Task<LivroViewModel> SelecionarPorId(int idLivro)
        {
            var livro = await _livroRepositorio.SelecionarPorId(idLivro);

            return _mapper.Map<LivroViewModel>(livro);
        }

        public async Task<ICollection<LivroViewModel>> SelecionarTodos()
        {
            var livros = await _livroRepositorio.SelecionarTodos();

            return _mapper.Map<ICollection<LivroViewModel>>(livros);
        }

        public async Task<ICollection<LivroViewModel>> SelecionarDisponiveis()
        {
            var livros = await _livroRepositorio.SelecionarTodos();
            var livrosDisponiveis = new List<Livro>();

            foreach(Livro l in livros)
            {
                if (l.Emprestado == false)
                    livrosDisponiveis.Add(l);
            }

            return _mapper.Map<ICollection<LivroViewModel>>(livrosDisponiveis);
        }

        public bool Sucesso()
        {
            return Erros.Count == 0;
        }

        public void Dispose()
        {
            _livroRepositorio?.Dispose();
        }

    }
}

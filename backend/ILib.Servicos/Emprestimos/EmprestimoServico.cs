﻿using AutoMapper;
using ILib.Dominio.Enums;
using ILib.Dominio.Entidades;
using ILib.Dominio.Repositorio;
using ILib.Servicos.Emprestimos.Validadores.Inclusao;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using ILib.Servicos.Livros;
using ILib.Servicos.Emprestimos.Validadores.Edicao;
using ILib.Servicos.Emprestimos.Validadores.Exclusao;
using ILib.Servicos.Emprestimos.Validadores.Confirmacao;
using ILib.Servicos.Emprestimos.Validadores.Devolucao;
using ILib.Servicos.Emprestimos.Validadores.SelecaoPosStatus;

namespace ILib.Servicos.Emprestimos
{
    public class EmprestimoServico : IEmprestimoServico
    {

        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly ILivroServico _livroServico;
        private readonly IEmprestimoValidacaoInclusao _emprestimoValidacaoInclusao;
        private readonly IEmprestimoValidacaoEdicao _emprestimoValidacaoEdicao;
        private readonly IEmprestimoValidacaoCancelamento _emprestimoValidacaoCancelamento;
        private readonly IEmprestimoValidacaoConfirmacao _emprestimoValidacaoConfirmacao;
        private readonly IEmprestimoValidacaoDevolucao _emprestimoValidacaoDevolucao;
        private readonly IEmprestimoValidacaoSelecaoPorStatus _emprestimoValidacaoSelecaoPosStatus;
        private readonly IMapper _mapper;
        public List<string> Erros { get; set; }

        public EmprestimoServico(
            IEmprestimoRepositorio emprestimoRepositorio,
            IEmprestimoValidacaoInclusao emprestimoValidacaoInclusao,
            IEmprestimoValidacaoEdicao emprestimoValidacaoEdicao,
            IEmprestimoValidacaoCancelamento emprestimoValidacaoCancelamento,
            IEmprestimoValidacaoConfirmacao emprestimoValidacaoConfirmacao,
            IEmprestimoValidacaoDevolucao emprestimoValidacaoDevolucao,
            IEmprestimoValidacaoSelecaoPorStatus emprestimoValidacaoSelecaoPosStatus,
            ILivroServico livroServico,
            IMapper mapper
            )
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _emprestimoValidacaoInclusao = emprestimoValidacaoInclusao;
            _emprestimoValidacaoEdicao = emprestimoValidacaoEdicao;
            _emprestimoValidacaoCancelamento = emprestimoValidacaoCancelamento;
            _emprestimoValidacaoConfirmacao = emprestimoValidacaoConfirmacao;
            _emprestimoValidacaoDevolucao = emprestimoValidacaoDevolucao;
            _emprestimoValidacaoSelecaoPosStatus = emprestimoValidacaoSelecaoPosStatus;
            _livroServico = livroServico;
            _mapper = mapper;
            Erros = new List<string>();
        }

        public bool Sucesso()
        {
            return Erros.Count == 0;
        }

        public async Task<EmprestimoViewModel> CancelaEmprestimo(EmprestimoViewModel emprestimo)
        {
            var validacao = _emprestimoValidacaoCancelamento.Validar(emprestimo);

            if (validacao.IsValid)
            {
                var obj = await _emprestimoRepositorio.SelecionarPorId(emprestimo.Id);

                obj.Status = EStatusEmprestimo.CANCELADO;

                await _emprestimoRepositorio.Editar(obj);

                _ = _livroServico.Devolver(emprestimo.LivroId);

                return _mapper.Map<EmprestimoViewModel>(obj);
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return emprestimo;
        }

        public async Task<EmprestimoViewModel> ConfirmaEmprestimo(EmprestimoViewModel emprestimo)
        {
            var validacao = _emprestimoValidacaoConfirmacao.Validar(emprestimo);

            if (validacao.IsValid)
            {
                var obj = await _emprestimoRepositorio.SelecionarPorId(emprestimo.Id);
                
                obj.DataEmprestimo = DateTime.Now;
                obj.Status = EStatusEmprestimo.EMPRESTADO;
                obj.DataPrevDevolucao = emprestimo.DataDevolucao != null ? emprestimo.DataDevolucao : DateTime.Now.AddDays(30);

                await _emprestimoRepositorio.Editar(obj);

                _ = _livroServico.Emprestar(emprestimo.LivroId);

                return _mapper.Map<EmprestimoViewModel>(obj);
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return emprestimo;
        }

        public async Task<EmprestimoViewModel> Criar(EmprestimoViewModel emprestimo)
        {
            var validacao = _emprestimoValidacaoInclusao.Validar(emprestimo);

            if (validacao.IsValid)
            {
                emprestimo.DataEmprestimo = DateTime.Now;
                emprestimo.DataPrevDevolucao = DateTime.Now.AddMonths(1);
                emprestimo.Status = (int) EStatusEmprestimo.PENDENTE;


                var obj = await _emprestimoRepositorio.Criar(_mapper.Map<Emprestimo>(emprestimo));
                _ = _livroServico.Emprestar(emprestimo.LivroId);
                return _mapper.Map<EmprestimoViewModel>(obj);
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return emprestimo;
        }

        public async Task<EmprestimoViewModel> Editar(EmprestimoViewModel emprestimo)
        {
            var validacao = _emprestimoValidacaoEdicao.Validar(emprestimo);
            if (validacao.IsValid)
            {
                var obj = await _emprestimoRepositorio.SelecionarPorId(emprestimo.Id);

                obj.DataPrevDevolucao = emprestimo.DataPrevDevolucao;
                obj.Observacao = emprestimo.Observacao;

                _ = await _emprestimoRepositorio.Editar(obj);

                return _mapper.Map<EmprestimoViewModel>(obj);
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return emprestimo;

        }

        public async Task<EmprestimoViewModel> RealizaDevolucao(EmprestimoViewModel emprestimo)
        {
            var validacao = _emprestimoValidacaoDevolucao.Validar(emprestimo);
            if (validacao.IsValid)
            {
                var obj = await _emprestimoRepositorio.SelecionarPorId(emprestimo.Id);

                obj.DataDevolucao = DateTime.Now;

               

                obj = await _emprestimoRepositorio.Editar(obj);
                _ = _livroServico.Devolver(obj.LivroId);

                return _mapper.Map<EmprestimoViewModel>(obj);
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return emprestimo;
        }

        public async Task<EmprestimoViewModel> SelecionarPorId(int IdEmprestimo)
        {
            return _mapper.Map<EmprestimoViewModel>(await _emprestimoRepositorio.SelecionarPorId(IdEmprestimo));
        }

        public async Task<ICollection<EmprestimoViewModel>> SelecionarPorStatus(int eStatus)
        {

            var validacao = _emprestimoValidacaoSelecaoPosStatus.Validar(new EmprestimoViewModel { Status = eStatus });
            if (validacao.IsValid)
            {
                var objs = await _emprestimoRepositorio.SelecionarPorStatus((EStatusEmprestimo) eStatus);


                return objs.Select(emprestimo => _mapper.Map<EmprestimoViewModel>(emprestimo)).ToList();
            }

            Erros.AddRange(validacao.Errors.Select(erro => erro.ErrorMessage).ToList());
            return null;


        }

        public async Task<ICollection<EmprestimoViewModel>> SelecionarTodos()
        {
            var objs = await _emprestimoRepositorio.SelecionarTodos();
            return objs.Select(emprestimo => _mapper.Map<EmprestimoViewModel>(emprestimo)).ToList();
        }
    }
}
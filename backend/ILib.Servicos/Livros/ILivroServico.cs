﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILib.Servicos.Livros
{
    public interface ILivroServico : IDisposable
    {
        Task<LivroViewModel> Criar(LivroViewModel livro);
        Task<LivroViewModel> Editar(LivroViewModel livro);
        Task<bool> Remover(int idLivro);
        Task<ICollection<LivroViewModel>> SelecionarTodos();
        Task<LivroViewModel> SelecionarPorId(int idLivro);
    }
}

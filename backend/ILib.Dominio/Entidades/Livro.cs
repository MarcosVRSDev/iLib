﻿using ILib.Core;
using ILib.Dominio.Enums;

namespace ILib.Dominio.Entidades
{
    public class Livro : Entidade
    {
        public string Codigo { get; set; }

        public string FotoUrl { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Editora { get; set; }

        public bool Emprestado { get; set; }

        public EEstadoLivro Estado { get; set; }

        public string Observacoes { get; set; }

    }
}
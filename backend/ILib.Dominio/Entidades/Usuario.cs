﻿using ILib.Core;
using System.Collections.Generic;

namespace ILib.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Uid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}

﻿using AutoMapper;
using ILib.Dominio.Entidades;
using ILib.Servicos.Livros;

namespace ILib.Servicos.AutoMapper
{
    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao()
        {
            CreateMap<LivroViewModel, Livro>().ReverseMap();
        }
    }
}
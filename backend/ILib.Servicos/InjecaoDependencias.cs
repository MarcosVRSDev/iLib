using AutoMapper;
using ILib.Servicos.Livros;
using ILib.Servicos.Livros.Validadores.Edicao;
using ILib.Servicos.Livros.Validadores.Exclusao;
using ILib.Servicos.Livros.Validadores.Inclusao;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ILib.Servicos
{
    public static class InjecaoDependencias
    {
        public static IServiceCollection AddServicos(this IServiceCollection services)
        {
            //Livros
            services.AddTransient<ILivroServico, LivroServico>();
            services.AddTransient<ILivroValidacaoInclusao, LivroValidacaoInclusao>();
            services.AddTransient<ILivroValidacaoExclusao, LivroValidacaoExclusao>();
            services.AddTransient<ILivroValidacaoEdicao, LivroValidacaoEdicao>();

            //Emprestimo

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

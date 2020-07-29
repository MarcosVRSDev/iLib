using AutoMapper;
using ILib.Servicos.Livros;
using ILib.Servicos.Livros.Validadores.Edicao;
using ILib.Servicos.Livros.Validadores.Emprestar;
using ILib.Servicos.Livros.Validadores.Devolucao;
using ILib.Servicos.Livros.Validadores.Exclusao;
using ILib.Servicos.Livros.Validadores.Inclusao;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ILib.Servicos.Emprestimos;
using ILib.Servicos.Emprestimos.Validadores.Inclusao;
using ILib.Servicos.Emprestimos.Validadores.Edicao;
using ILib.Servicos.Emprestimos.Validadores.Exclusao;
using ILib.Servicos.Emprestimos.Validadores.Confirmacao;
using ILib.Servicos.Emprestimos.Validadores.Devolucao;
using ILib.Servicos.Emprestimos.Validadores.SelecaoPosStatus;
using ILib.Servicos.Usuarios;

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
            services.AddTransient<ILivroValidacaoEmprestar, LivroValidacaoEmprestar>();
            services.AddTransient<ILivroValidacaoDevolucao, LivroValidacaoDevolucao>();

            //Emprestimo
            services.AddTransient<IEmprestimoServico, EmprestimoServico>();
            services.AddTransient<IEmprestimoValidacaoInclusao, EmprestimoValidacaoInclusao>();
            services.AddTransient<IEmprestimoValidacaoEdicao, EmprestimoValidacaoEdicao>();
            services.AddTransient<IEmprestimoValidacaoCancelamento, EmprestimoValidacaoCancelamento>();
            services.AddTransient<IEmprestimoValidacaoConfirmacao, EmprestimoValidacaoConfirmacao>();
            services.AddTransient<IEmprestimoValidacaoDevolucao, EmprestimoValidacaoDevolucao>();
            services.AddTransient<IEmprestimoValidacaoSelecaoPorStatus, EmprestimoValidacaoSelecaoPorStatus>();

            //Usuarios
            services.AddTransient<IUsuarioServico, UsuarioServico>();

            //AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

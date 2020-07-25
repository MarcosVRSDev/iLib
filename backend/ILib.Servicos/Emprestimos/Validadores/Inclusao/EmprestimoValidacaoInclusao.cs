using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;

namespace ILib.Servicos.Emprestimos.Validadores.Inclusao
{
    public class EmprestimoValidacaoInclusao : AbstractValidator<EmprestimoViewModel>, IEmprestimoValidacaoInclusao
    {

        private readonly ILivroRepositorio _livroRepositorio;

        public EmprestimoValidacaoInclusao(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;


            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .DependentRules(() =>
                {

                    RuleFor(x => x.LivroId)
                        .NotNull()
                        .WithMessage("É preciso informar informar o Id do livro")
                        .NotEmpty()
                        .WithMessage("É preciso informar informar o Id do livro")
                        .DependentRules(() => 
                        {
                            RuleFor(x => x.LivroId)
                                .MustAsync(async (id, cancellation) =>
                                {
                                    var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                                    if (livroExistente != null)
                                        return true;
                                    return false;
                                })
                                .WithMessage(x => $"Livro Id: {x.LivroId} não existe.")
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.LivroId)
                                    .MustAsync(async (id, cancellation) =>
                                     {
                                         var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                                         return !livroExistente.Emprestado;

                                     }).WithMessage(x => $"Livro Id: {x.LivroId} está emprestado.");
                                });
                                
                        });


                    RuleFor(x => x.UsuarioId)
                        .NotNull()
                        .WithMessage("É preciso informar informar o Id do usuario")
                        .NotEmpty()
                        .WithMessage("É preciso informar informar o Id do usuario");

                });


        }

        public ValidationResult Validar(EmprestimoViewModel obj)
        {
            return Validate(obj);
        }
    }
}

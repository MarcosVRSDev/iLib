using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using ILib.Dominio.Repositorio;
using System.Threading.Tasks;

namespace ILib.Servicos.Livros.Validadores.Emprestar
{
    public class LivroValidacaoEmprestar : AbstractValidator<LivroViewModel>, ILivroValidacaoEmprestar
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroValidacaoEmprestar(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Não é possível excluir um livro sem informar o ID.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
                    .MustAsync(async (id, cancellation) =>
                    {
                        var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                        if (livroExistente != null)
                            return true;
                        return false;
                    })
                    .WithMessage("Esse livro não existe na aplicação. O ID informado pode estar incorreto.")
                    .MustAsync(async (id, cancellation) =>
                    {
                        var livroValido = await _livroRepositorio.SelecionarPorId(id);
                        if (livroValido.Emprestado == true)
                            return false;
                        
                        return true;
                    }).WithMessage("O Livro já está emprestado.");
                });
        }

        public ValidationResult Validar(LivroViewModel obj)
        {
            return Validate(obj);
        }
    }
}

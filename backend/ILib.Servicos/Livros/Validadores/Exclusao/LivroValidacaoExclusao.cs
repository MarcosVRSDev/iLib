using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;

namespace ILib.Servicos.Livros.Validadores.Exclusao
{
    public class LivroValidacaoExclusao : AbstractValidator<LivroViewModel>, ILivroValidacaoExclusao
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroValidacaoExclusao(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("Não é possível excluir um livro sem informar o ID.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
                    {
                        var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                        if (livroExistente != null)
                            return true;
                        return false;
                    }).WithMessage("Esse livro não existe na aplicação. O ID informado pode estar incorreto.");
                });
        }

        public ValidationResult Validar(LivroViewModel obj)
        {
            return Validate(obj);
        }
    }
}

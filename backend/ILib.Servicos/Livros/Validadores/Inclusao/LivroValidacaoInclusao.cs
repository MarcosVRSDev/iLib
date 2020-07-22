using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;
using System.Data;

namespace ILib.Servicos.Livros.Validadores.Inclusao
{
    public class LivroValidacaoInclusao : AbstractValidator<LivroViewModel>, ILivroValidacaoInclusao
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroValidacaoInclusao(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("Não pode ser criado um livro sem dados.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Codigo)
                        .NotNull()
                        .WithMessage("É preciso informar um código para o livro. Sugetão: DEV-001")
                        .NotEmpty()
                        .WithMessage("É preciso informar um código para o livro. Sugetão: DEV-001");

                    RuleFor(x => x.Titulo)
                        .NotNull()
                        .WithMessage("É preciso um título para esse livro.")
                        .NotEmpty()
                        .WithMessage("É preciso um título para esse livro.");

                    RuleFor(x => x.Estado)
                        .NotNull()
                        .WithMessage("É preciso informar o estado livro. Estados: Bom, Regular, Ruim.");

                    RuleFor(x => x.FotoUrl)
                        .NotNull()
                        .WithMessage("É necessário informar a URL da foto do livro.")
                        .NotEmpty()
                        .WithMessage("É necessário informar a URL da foto do livro.");

                    RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
                    {
                        var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                        if (livroExistente == null)
                            return true;
                        return false;
                    }).WithMessage("Esse livro já existe na aplicação. Tente informar um novo ID.");
                });
        }

        public ValidationResult Validar(LivroViewModel obj)
        {
            return Validate(obj);
        }
    }
}

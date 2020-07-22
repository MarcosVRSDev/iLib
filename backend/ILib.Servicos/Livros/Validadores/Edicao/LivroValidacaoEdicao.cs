using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;

namespace ILib.Servicos.Livros.Validadores.Edicao
{
    public class LivroValidacaoEdicao : AbstractValidator<LivroViewModel>, ILivroValidacaoEdicao
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroValidacaoEdicao(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;

            RuleFor(x => x)
                .NotNull()
                .WithMessage("Deve ser informados novos dados para alteração do livro.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .NotEmpty()
                        .WithMessage("É necessário informar o ID para editar um livro.")
                        .NotNull()
                        .WithMessage("É necessário informar o ID para editar um livro.");

                    RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
                    {
                        var livroExistente = await _livroRepositorio.SelecionarPorId(id);
                        if (livroExistente != null)
                            return true;
                        return false;
                    }).WithMessage("Esse livro não existe na aplicação. Tente informar um outro ID.");

                    RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
                    {
                        var livroDisponivel = await _livroRepositorio.SelecionarPorId(id);
                        if (livroDisponivel.Emprestado == false)
                            return true;
                        return false;
                    }).WithMessage("Esse livro está emprestado. Não é possível editar livros emprestados.");

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
                });
        }

        public ValidationResult Validar(LivroViewModel obj)
        {
            return Validate(obj);
        }
    }
}

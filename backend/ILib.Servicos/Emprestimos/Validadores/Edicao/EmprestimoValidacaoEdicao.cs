using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;

namespace ILib.Servicos.Emprestimos.Validadores.Edicao
{
    public class EmprestimoValidacaoEdicao : AbstractValidator<EmprestimoViewModel>, IEmprestimoValidacaoEdicao
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        public EmprestimoValidacaoEdicao(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;

            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .NotNull()
                        .WithMessage("É preciso informar o Id do emprestimo")
                        .NotEmpty()
                        .WithMessage("É preciso informar o Id do emprestimo")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Id)
                                .MustAsync(async (id, cancellation) =>
                                {
                                    var emprestimoExistente = await _emprestimoRepositorio.SelecionarPorId(id);
                                    if (emprestimoExistente != null)
                                        return true;
                                    return false;
                                })
                                .WithMessage(x => $"Emprestimo Id: {x.Id} não existe.");

                        });

                    RuleFor(x => x.DataPrevDevolucao)
                        .NotNull()
                        .WithMessage("É preciso informar informar a data de previsão da devolução")
                        .NotEmpty()
                        .WithMessage("É preciso informar informar a data de previsão da devolução");

                    
                    RuleFor(x => x.Observacao)
                        .MaximumLength(255)
                        .WithMessage("Tamanho máximo do campo de observação é de 255 caracteres");

                });
        }

        public ValidationResult Validar(EmprestimoViewModel obj)
        {
            return Validate(obj);
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Repositorio;

namespace ILib.Servicos.Emprestimos.Validadores.Confirmacao
{
    public class EmprestimoValidacaoConfirmacao : AbstractValidator<EmprestimoViewModel>, IEmprestimoValidacaoConfirmacao
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        public EmprestimoValidacaoConfirmacao(IEmprestimoRepositorio emprestimoRepositorio)
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
               });
        }

        public ValidationResult Validar(EmprestimoViewModel obj)
        {
            return Validate(obj);
        }
    }
}

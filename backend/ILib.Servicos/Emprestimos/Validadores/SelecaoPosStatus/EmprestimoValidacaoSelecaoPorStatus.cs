using FluentValidation;
using FluentValidation.Results;
using ILib.Dominio.Enums;
using System;
using System.Threading.Tasks;

namespace ILib.Servicos.Emprestimos.Validadores.SelecaoPosStatus
{
    public class EmprestimoValidacaoSelecaoPorStatus : AbstractValidator<EmprestimoViewModel>, IEmprestimoValidacaoSelecaoPorStatus
    {
        public EmprestimoValidacaoSelecaoPorStatus()
        {
            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .DependentRules(() =>
                {

                    RuleFor(x => x.Status)
                        .NotNull()
                        .WithMessage("É preciso informar informar o Status")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Status)
                                .Must(ValidarStatusEmprestimo)
                                .WithMessage("Status de emprestimo inválido.");
                        });

                });
        }

        public bool ValidarStatusEmprestimo(int statusEnum)
        {
            return Enum.IsDefined(typeof(EStatusEmprestimo), statusEnum);
        }

        public async Task<ValidationResult> Validar(EmprestimoViewModel obj)
        {
            return await ValidateAsync(obj);
        }
    }
}

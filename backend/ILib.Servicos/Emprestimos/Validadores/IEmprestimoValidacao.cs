using FluentValidation.Results;
using System.Threading.Tasks;

namespace ILib.Servicos.Emprestimos.Validadores
{
    public interface IEmprestimoValidacao<T>
        where T: EmprestimoViewModel
    {
        Task<ValidationResult> Validar(T obj);
    }
}

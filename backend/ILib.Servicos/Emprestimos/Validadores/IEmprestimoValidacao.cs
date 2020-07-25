using FluentValidation.Results;

namespace ILib.Servicos.Emprestimos.Validadores
{
    public interface IEmprestimoValidacao<T>
        where T: EmprestimoViewModel
    {
        ValidationResult Validar(T obj);
    }
}
